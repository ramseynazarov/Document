using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Document.Models;
using Document.Models.ViewModels.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Document.Controllers;

public class AuthController : BaseController
{
    private readonly DataContext _context;

    public AuthController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(AuthVm model)
    {
        if (!ModelState.IsValid) return View(model);
        var user = _context.Users.FirstOrDefault(x=>x.Phone.Equals(model.Phone));
        if (user == null)
        {
            ModelState.AddModelError("", "Логин или пароль не корректный!");
            return View(model);
        }
        if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
        {
            ModelState.AddModelError("", "Логин или пароль не корректный!");
            return View(model);
        }
        await Authenticate(user.Phone, user.Id);
        return Redirect("Document/GetAll");
    }
    
    private async Task Authenticate(string phone,Guid id)
    {
        var list = new List<Claim>
        {
            new(ClaimsIdentity.DefaultNameClaimType, phone),
            new(ClaimTypes.NameIdentifier, id.ToString())
        };
        var currentUserId = new ClaimsIdentity(list, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(currentUserId));
    }
    
    [HttpGet]
    public IActionResult Logout()
    {
        return RedirectToAction("Login", "Auth");
    }
}