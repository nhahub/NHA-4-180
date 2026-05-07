using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rizk.Api.Data;
using Rizk.Api.Models;

namespace Rizk.Api.Services;

public class WalletService : IWalletService
{
    private readonly ApplicationDbContext _context;

    public WalletService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ChargeWalletAsync(int userId, decimal amount)
    {
        if (amount <= 0)
            return false;

        var wallet = await _context.Wallets
            .FirstOrDefaultAsync(w => w.UserID == userId);

        if (wallet == null)
            return false;

        wallet.Available_Balance += amount;

        var transactionLog = new TransactionLog
        {
            Amount = amount,
            Type = "Charge",
            CreatedAt = DateTime.UtcNow,
            WalletID = wallet.ID
        };

        _context.TransactionLogs.Add(transactionLog);

        return await _context.SaveChangesAsync() > 0;
    }
}
