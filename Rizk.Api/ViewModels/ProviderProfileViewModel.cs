namespace Rizk.Api.ViewModels;

public class ProviderProfileViewModel
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public bool IsVerified { get; set; }
    public int YearsOfExperience { get; set; }
}
