namespace Rizk.Api.Models;

public class Wallet
{
    public int ID { get; set; }
    public decimal Frozen_Balance { get; set; }
    public decimal Available_Balance { get; set; }
    public int UserID { get; set; }

    // Navigation Properties
    public User User { get; set; } = null!;
    public ICollection<TransactionLog> TransactionLogs { get; set; } = new List<TransactionLog>();
}
