namespace Rizk.Api.Models;

public class Review
{
    public int ID { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public int VisitID { get; set; }

    // Navigation Properties
    public Visit Visit { get; set; } = null!;
}
