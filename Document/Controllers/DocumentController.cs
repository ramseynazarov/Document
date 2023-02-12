using System;
using System.Linq;
using System.Threading.Tasks;
using Document.Models;
using Document.Models.ViewModels.Document;
using Documet.Models;
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
       
        var users = await _dataContext.Users.ToListAsync();
        
        var document = new CreateDocVm()
        {
            Departments = departments,
            Users = users
        };
        return View(document);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDocVm documentViewModel)
    {
        var userId = GetCurrentUserId();
        
        var document = new Models.Document()
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
            DepartamentId = documentViewModel.DepartmentId
        };
        await _dataContext.Documents.AddAsync(document);
        await _dataContext.SaveChangesAsync();
        
        
      
        foreach (var userDocuments in documentViewModel.UserId.Select(uGuid => new UserDocuments()
                 {
                     Id = Guid.NewGuid(),
                     DocumentId = document.Id,
                     UserId = uGuid
                 }))
        {
            await _dataContext.UserDocuments.AddAsync(userDocuments);
            await _dataContext.SaveChangesAsync();
        }
        
        return RedirectToAction("GetAll","Document");
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
            return View(new Models.Document());
        }
        
        var newDocument = new Models.Document()
        {
            Id = document.Id,
            Correspondent = document.Correspondent,
            Topic = document.Topic,
            Type = document.Type,
            CorrespondentNumber = document.CorrespondentNumber,
            DocumentNumber = document.DocumentNumber,
            CreatedAtCorrespondent = document.CreatedAtCorrespondent,
            UserDocuments = document.UserDocuments.ToList(),
            UserId = currentUserId,
            Department = document.Department
        };
        
        return View(newDocument);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var doc = await _dataContext.Documents.Select(x => new Models.Document
        {
            Id = x.Id,
            Type = x.Type,
            Correspondent = x.Correspondent,
            DocumentNumber = x.DocumentNumber,
            Topic = x.Topic,
            DepartamentId = x.DepartamentId
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
}