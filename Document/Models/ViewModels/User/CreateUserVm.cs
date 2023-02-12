using System;
using System.Collections.Generic;

namespace Document.Models.ViewModels.User;

public class CreateUserVm
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public Guid DepartmentId { get; set; } = new("e7bf76fc-035a-4e5c-81ae-6492421107be");
    public List<Department> Departments { get; set; }
}