namespace Rizk.Api.ViewModels;

public class ProposalViewModel
{
    public int Id { get; set; }
    public decimal VisitFee { get; set; }
    public string Status { get; set; } = string.Empty;
    public string ProviderName { get; set; } = string.Empty;
}
