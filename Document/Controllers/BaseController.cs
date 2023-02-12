using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Document.Controllers;

public class BaseController : Controller
{
    protected Guid GetCurrentUserId()=>
        HttpContext.User.Identity is not ClaimsIdentity
            ? Guid.Empty : Guid.Parse(HttpContext.User.Claims
            .Where(x => x.Type == ClaimTypes.NameIdentifier)
            .Select(x => x.Value)
            .FirstOrDefault() ?? string.Empty);
}