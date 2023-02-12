using System;
using System.Collections.Generic;
using Documet.Models;

namespace Document.Models;

public class Department
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual ICollection<User> Users { get; set; }
}