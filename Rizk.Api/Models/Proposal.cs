namespace Rizk.Api.Models;

public class Proposal
{
    public int ID { get; set; }
    public decimal VisitFee { get; set; }
    public string Status { get; set; } = string.Empty;
    public int ProviderID { get; set; }
    public int ServiceRequestID { get; set; }

    // Navigation Properties
    public User Provider { get; set; } = null!;
    public ServiceRequest ServiceRequest { get; set; } = null!;
    public ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
