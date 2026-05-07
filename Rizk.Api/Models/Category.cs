namespace Rizk.Api.Models;

public class Category
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal VisitFee { get; set; }

    // Navigation Properties
    public ICollection<ProviderProfile> ProviderProfiles { get; set; } = new List<ProviderProfile>();
    public ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();
}
