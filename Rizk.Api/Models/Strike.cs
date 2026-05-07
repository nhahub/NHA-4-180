using System;

namespace Rizk.Api.Models;

public class Strike
{
    public int ID { get; set; }
    public string Reason { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public int ProviderID { get; set; }

    // Navigation Properties
    public User Provider { get; set; } = null!;
}
