using Microsoft.EntityFrameworkCore;
using Rizk.Api.Models;

namespace Rizk.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<ProviderProfile> ProviderProfiles { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<ServiceRequest> ServiceRequests { get; set; } = null!;
    public DbSet<Proposal> Proposals { get; set; } = null!;
    public DbSet<Visit> Visits { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
    public DbSet<Wallet> Wallets { get; set; } = null!;
    public DbSet<TransactionLog> TransactionLogs { get; set; } = null!;
    public DbSet<Strike> Strikes { get; set; } = null!;
    public DbSet<Notification> Notifications { get; set; } = null!;
    public DbSet<AuditLog> AuditLogs { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // 1-to-1: User and ProviderProfile
        modelBuilder.Entity<User>()
            .HasOne(u => u.ProviderProfile)
            .WithOne(p => p.User)
            .HasForeignKey<ProviderProfile>(p => p.UserID)
            .OnDelete(DeleteBehavior.Cascade);

        // 1-to-1: User and Wallet
        modelBuilder.Entity<User>()
            .HasOne(u => u.Wallet)
            .WithOne(w => w.User)
            .HasForeignKey<Wallet>(w => w.UserID)
            .OnDelete(DeleteBehavior.Cascade);

        // 1-to-1: Visit and Review
        modelBuilder.Entity<Visit>()
            .HasOne(v => v.Review)
            .WithOne(r => r.Visit)
            .HasForeignKey<Review>(r => r.VisitID)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure Restrict for relationships to prevent multiple cascade paths

        // ServiceRequest -> Customer (User)
        modelBuilder.Entity<ServiceRequest>()
            .HasOne(sr => sr.Customer)
            .WithMany(u => u.ServiceRequests)
            .HasForeignKey(sr => sr.CustomerID)
            .OnDelete(DeleteBehavior.Restrict);

        // ServiceRequest -> Category
        modelBuilder.Entity<ServiceRequest>()
            .HasOne(sr => sr.Category)
            .WithMany(c => c.ServiceRequests)
            .HasForeignKey(sr => sr.CategoryID)
            .OnDelete(DeleteBehavior.Restrict);

        // ProviderProfile -> Category
        modelBuilder.Entity<ProviderProfile>()
            .HasOne(p => p.Category)
            .WithMany(c => c.ProviderProfiles)
            .HasForeignKey(p => p.CategoryID)
            .OnDelete(DeleteBehavior.Restrict);

        // Proposal -> Provider (User)
        modelBuilder.Entity<Proposal>()
            .HasOne(p => p.Provider)
            .WithMany() // Can be mapped to a specific collection if needed
            .HasForeignKey(p => p.ProviderID)
            .OnDelete(DeleteBehavior.Restrict);

        // Proposal -> ServiceRequest
        modelBuilder.Entity<Proposal>()
            .HasOne(p => p.ServiceRequest)
            .WithMany(sr => sr.Proposals)
            .HasForeignKey(p => p.ServiceRequestID)
            .OnDelete(DeleteBehavior.Restrict);

        // Visit -> ServiceRequest
        modelBuilder.Entity<Visit>()
            .HasOne(v => v.ServiceRequest)
            .WithMany(sr => sr.Visits)
            .HasForeignKey(v => v.ServiceRequestID)
            .OnDelete(DeleteBehavior.Restrict);

        // Visit -> Proposal
        modelBuilder.Entity<Visit>()
            .HasOne(v => v.Proposal)
            .WithMany(p => p.Visits)
            .HasForeignKey(v => v.ProposalID)
            .OnDelete(DeleteBehavior.Restrict);

        // AuditLog -> Admin (User)
        modelBuilder.Entity<AuditLog>()
            .HasOne(a => a.Admin)
            .WithMany(u => u.AuditLogsAsAdmin)
            .HasForeignKey(a => a.AdminID)
            .OnDelete(DeleteBehavior.Restrict);

        // AuditLog -> TargetUser (User)
        modelBuilder.Entity<AuditLog>()
            .HasOne(a => a.TargetUser)
            .WithMany(u => u.AuditLogsAsTarget)
            .HasForeignKey(a => a.TargetUserID)
            .OnDelete(DeleteBehavior.Restrict);

        // Strike -> Provider (User)
        modelBuilder.Entity<Strike>()
            .HasOne(s => s.Provider)
            .WithMany(u => u.Strikes)
            .HasForeignKey(s => s.ProviderID)
            .OnDelete(DeleteBehavior.Restrict);

        // Notification -> User
        modelBuilder.Entity<Notification>()
            .HasOne(n => n.User)
            .WithMany(u => u.Notifications)
            .HasForeignKey(n => n.UserID)
            .OnDelete(DeleteBehavior.Cascade);
            
        // TransactionLog -> Wallet
        modelBuilder.Entity<TransactionLog>()
            .HasOne(t => t.Wallet)
            .WithMany(w => w.TransactionLogs)
            .HasForeignKey(t => t.WalletID)
            .OnDelete(DeleteBehavior.Cascade);

        // تحديد دقة الأرقام العشرية للفلوس
        modelBuilder.Entity<Wallet>().Property(w => w.Frozen_Balance).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Wallet>().Property(w => w.Available_Balance).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Category>().Property(c => c.VisitFee).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Proposal>().Property(p => p.VisitFee).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<TransactionLog>().Property(t => t.Amount).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Visit>().Property(v => v.FinalQuote).HasColumnType("decimal(18,2)");
    }
}
