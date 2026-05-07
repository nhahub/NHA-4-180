namespace Rizk.Api.Models;

public class ProviderProfile
{
    public int ID { get; set; }
    public int UserID { get; set; }
    public string N_Id { get; set; } = string.Empty;
    public string CriminalRecord { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public bool IsVerified { get; set; }
    public int YearsOfExperience { get; set; }
    public int CategoryID { get; set; }

    // Navigation Properties
    public User User { get; set; } = null!;
    public Category Category { get; set; } = null!;
}
