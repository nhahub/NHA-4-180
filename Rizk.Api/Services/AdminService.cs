using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rizk.Api.Data;
using Rizk.Api.Models;

namespace Rizk.Api.Services;

public class AdminService : IAdminService
{
    private readonly ApplicationDbContext _context;

    public AdminService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> VerifyProviderAsync(int providerId)
    {
        var providerProfile = await _context.ProviderProfiles
            .FirstOrDefaultAsync(p => p.ID == providerId);

        if (providerProfile == null)
            return false;

        providerProfile.IsVerified = true;

        // Note: For a real app, AdminID would come from current context/auth user
        var auditLog = new AuditLog
        {
            Action = "Verified Provider",
            CreatedAt = DateTime.UtcNow,
            AdminID = 1, // Placeholder
            TargetUserID = providerProfile.UserID
        };

        _context.AuditLogs.Add(auditLog);

        return await _context.SaveChangesAsync() > 0;
    }
}
