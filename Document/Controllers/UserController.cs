using System;
using System.Linq;
using System.Threading.Tasks;
using Document.Models;
using Document.Models.ViewModels.User;
using Documet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Document.Controllers;

public class UserController : BaseController
{
    private readonly DataContext _dataContext;
    public UserController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var departments = await _dataContext.Departments.ToListAsync();
        var list = new CreateUserVm
        {
            Departments = departments
        };
        return View(list);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserVm userViewModel)
    {
        var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Phone.Equals(userViewModel.Phone));
        if (user != null)
        {
            ModelState.AddModelError("", "Такой пользователь уже существует!");
            return View(userViewModel);
        }
        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Name = userViewModel.Name,
            Password = BCrypt.Net.BCrypt.HashPassword(userViewModel.Password),
            Phone = userViewModel.Phone,
            CreatedAt = DateTime.UtcNow,
            DepartmentId = userViewModel.DepartmentId
        };
        await _dataContext.Users.AddAsync(newUser);
        await _dataContext.SaveChangesAsync();
        return RedirectToAction("GetAll","User");
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult GetAll()
    {
        var users = _dataContext.Users.Select(x => new User()
        {
            Id = x.Id,
            Department = x.Department,
            Name = x.Name,
        }).ToList();
        return View(users);
    }
    
    
    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        var user = await _dataContext.Users.FindAsync(id);
        if (user == null)
        {
            return RedirectToAction("GetAll","User");
        }
        _dataContext.Users.Remove(user);
        await _dataContext.SaveChangesAsync();
        return RedirectToAction("GetAll","User");
    }
}