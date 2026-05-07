using System;

namespace Rizk.Api.Models;

public class Notification
{
    public int ID { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UserID { get; set; }

    // Navigation Properties
    public User User { get; set; } = null!;
}
