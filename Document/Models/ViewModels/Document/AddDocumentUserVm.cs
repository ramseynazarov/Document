using System;
using System.Collections.Generic;

namespace Document.Models.ViewModels.Document;

public class AddDocumentUserVm
{
    public Guid DocumentId { get; set; }
    public List<Models.User> Users { get; set; }
    public List<Guid> UserIds { get; set; }
}