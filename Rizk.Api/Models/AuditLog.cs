using System;

namespace Rizk.Api.Models;

public class AuditLog
{
    public int ID { get; set; }
    public string Action { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public int AdminID { get; set; }
    public int TargetUserID { get; set; }

    // Navigation Properties
    public User Admin { get; set; } = null!;
    public User TargetUser { get; set; } = null!;
}
