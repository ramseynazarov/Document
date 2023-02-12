using System;

namespace Document.Models;

public class User
{
    public Guid Id { get; set; }
    
    public Guid DepartmentId { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public DateTime CreatedAt { get; set; }

    public virtual Department Department { get; set; }
}