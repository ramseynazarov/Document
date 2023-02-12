using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Document.Controllers;

public class BaseController : Controller
{
    protected Guid GetCurrentUserId()=>
        Guid.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString());
}