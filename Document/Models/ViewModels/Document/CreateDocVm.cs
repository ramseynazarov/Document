using System;
using System.Collections.Generic;

namespace Document.Models.ViewModels.Document;

public class CreateDocVm
{
    public string Type { get; set; }
    public string Topic { get; set; }
    public string Correspondent { get; set; }
    public string CorrespondentNumber { get; set; }
    public int DocumentNumber { get; set; }
    public Guid DepartmentId { get; set; }
    public DateTime EndDate { get; set; }
    public int EndHour { get; set; }
    public int EndMinute { get; set; }
    public List<Department> Departments { get; set; }

    public bool CanAddUsers { get; set; }
    // public List<Models.User> Users { get; set; }
}