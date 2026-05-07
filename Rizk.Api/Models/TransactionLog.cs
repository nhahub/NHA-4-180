using System;

namespace Rizk.Api.Models;

public class TransactionLog
{
    public int ID { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public int WalletID { get; set; }

    // Navigation Properties
    public Wallet Wallet { get; set; } = null!;
}
