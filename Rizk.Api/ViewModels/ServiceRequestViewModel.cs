namespace Rizk.Api.ViewModels;

public class ServiceRequestViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
}
