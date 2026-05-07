namespace Rizk.Api.Models;

public class ServiceRequest
{
    public int ID { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public int CustomerID { get; set; }
    public int CategoryID { get; set; }

    // Navigation Properties
    public User Customer { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();
    public ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
