namespace Rizk.Api.Models;

public class User
{
    public int ID { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;

    // Navigation Properties
    public Wallet? Wallet { get; set; }
    public ProviderProfile? ProviderProfile { get; set; }
    public ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    public ICollection<Strike> Strikes { get; set; } = new List<Strike>();
    public ICollection<AuditLog> AuditLogsAsAdmin { get; set; } = new List<AuditLog>();
    public ICollection<AuditLog> AuditLogsAsTarget { get; set; } = new List<AuditLog>();
}
