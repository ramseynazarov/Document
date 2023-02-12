using System;
using System.Collections.Generic;

namespace Document.Models.ViewModels.Document;

public class DocumentVm
{
    public int DocumentNumber { get; set; }
    public string Correspondent { get; set; }
    public string DepartmentName { get; set; }
    public string Type { get; set; }
    public string StatusName { get; set; }
    public Guid Id { get; set; }
    public string Topic { get; set; }
    public Guid DepartmentId { get; set; }
    public string CorrespondentNumber { get; set; }
    public DateTime CreatedAtCorrespondent { get; set; }
    public List<UserDocumentVm> UserDocuments { get; set; }
    public Guid UserId { get; set; }
    public Department Department { get; set; }
}