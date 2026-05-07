namespace Rizk.Api.Models;

public class Visit
{
    public int ID { get; set; }
    public string Status { get; set; } = string.Empty;
    public decimal FinalQuote { get; set; }
    public int ServiceRequestID { get; set; }
    public int ProposalID { get; set; }

    // Navigation Properties
    public ServiceRequest ServiceRequest { get; set; } = null!;
    public Proposal Proposal { get; set; } = null!;
    public Review? Review { get; set; }
}
