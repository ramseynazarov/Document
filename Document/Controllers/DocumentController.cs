using System;
using System.Linq;
using System.Threading.Tasks;
using Document.Models;
using Document.Models.ViewModels.Document;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Document.Controllers;

public class DocumentController : BaseController
{
    private readonly DataContext _dataContext;

    public DocumentController(DataContext context)
    {
        _dataContext = context;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var departments = await _dataContext.Departments.ToListAsync();

        var currentUserId = GetCurrentUserId();
        
        var users = await _dataContext.Users.Where(x=>!x.Id.Equals(currentUserId)).ToListAsync();
        
        var document = new CreateDocVm()
        {
            Departments = departments,
            // Users = users
        };
        return View(document);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDocVm documentViewModel)
    {
        var userId = GetCurrentUserId();
        
        var document = new Models.Document
        {
            Id = Guid.NewGuid(),
            Topic = documentViewModel.Topic,
            Type = documentViewModel.Type,
            CorrespondentNumber = documentViewModel.CorrespondentNumber,
            Correspondent = documentViewModel.Correspondent,
            CreatedAtCorrespondent = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow,
            DocumentNumber = documentViewModel.DocumentNumber,
            UserId = userId,
            DepartmentId = documentViewModel.DepartmentId,
            EndDateTime = documentViewModel.EndDate.AddHours(documentViewModel.EndHour).AddMinutes(documentViewModel.EndMinute)
        };
        await _dataContext.Documents.AddAsync(document);
        await _dataContext.SaveChangesAsync();
        
        return RedirectToAction("GetAll","Document");
    }

    [HttpGet]
    public async Task<IActionResult> Accept(Guid id)
    {
        var document = await _dataContext.Documents.FindAsync(id);
        if (document == null)
        {
            return RedirectToAction("GetAll");
        }

        document.StatusId = 4;

        await _dataContext.SaveChangesAsync();
        return RedirectToAction("GetById", new { id });
    }
    
    [HttpGet]
    public async Task<IActionResult> Reject(Guid id)
    {
        var document = await _dataContext.Documents.FindAsync(id);
        if (document == null)
        {
            return RedirectToAction("GetAll");
        }

        document.StatusId = 3;

        await _dataContext.SaveChangesAsync();
        return RedirectToAction("GetById", new { id });
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetById(Guid id)
    {
        var currentUserId = GetCurrentUserId();
       
        var document = await _dataContext.Documents.FindAsync(id);
        if (document == null)
        {
            ModelState.AddModelError("", "Документ не найден!");
            return View(new DocumentVm());
        }
        
        var newDocument = new DocumentVm
        {
            Id = document.Id,
            Correspondent = document.Correspondent,
            Topic = document.Topic,
            Type = document.Type,
            CorrespondentNumber = document.CorrespondentNumber,
            DocumentNumber = document.DocumentNumber,
            CreatedAtCorrespondent = document.CreatedAtCorrespondent,
            UserDocuments = document.UserDocuments.Select(x=> new UserDocumentVm
            {
                UserId = x.UserId,
                UserName = x.User.Name
            }).ToList(),
            UserId = currentUserId,
            Department = document.Department,
            StatusName = document.Status.Name,
            DepartmentName = document.Department.Name
        };
        
        return View(newDocument);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var doc = await _dataContext.Documents.Select(x => new DocumentVm
        {
            Id = x.Id,
            Type = x.Type,
            Correspondent = x.Correspondent,
            DocumentNumber = x.DocumentNumber,
            Topic = x.Topic,
            DepartmentId = x.DepartmentId,
            DepartmentName = x.Department.Name,
            StatusName = x.Status.Name,
            UserId = x.UserId,
            EndDateTime = x.EndDateTime,
            CanAddUser = !x.UserDocuments.Any()
        }).ToListAsync();
       
        return View(doc);
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        var document = await _dataContext.Documents.FindAsync(id);

        if (document != null)
        {
            _dataContext.Documents.Remove(document);
            await _dataContext.SaveChangesAsync();
        }
       
        return RedirectToAction("GetAll","Document");
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> AddUsers(Guid documentId)
    {
        var currentUserId = GetCurrentUserId();
        var users = await _dataContext.Users.Where(x=>!x.Id.Equals(currentUserId)).ToListAsync();
        return View(new AddDocumentUserVm
        {
            Users = users,
            DocumentId = documentId
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddUsers(AddDocumentUserVm addDocumentUserVm)
    {
        var list = addDocumentUserVm.UserIds.Select(x => new UserDocuments
        {
            Id = Guid.NewGuid(),
            DocumentId = addDocumentUserVm.DocumentId,
            UserId = x
        });
        await _dataContext.UserDocuments.AddRangeAsync(list);
        await _dataContext.SaveChangesAsync();
        return RedirectToAction("GetAll");
    }
}