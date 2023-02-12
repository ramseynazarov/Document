using System;

namespace Document.Models;

public class UserDocuments
{
    public Guid Id { get; set; }

    public Guid DocumentId { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public virtual Document Document { get; set; }
}