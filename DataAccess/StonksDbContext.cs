using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess;

public class StonksDbContext : DbContext
{
    public StonksDbContext() : base() { }
    public StonksDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users {get;set;}
    public DbSet<Currency> Currencies {get;set;}
    public DbSet<Transaction> Transactions {get;set;}
    public DbSet<Profile> Profiles {get;set;}
    public DbSet<Wallet> Wallets {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Profile>().HasOne<User>().WithMany().HasForeignKey(p => p.UserIdFk);
        modelBuilder.Entity<Wallet>().HasOne<User>().WithMany().HasForeignKey(p => p.UserIdFk);
        modelBuilder.Entity<Wallet>().HasOne<Currency>().WithMany().HasForeignKey(p => p.CurrencyIdFk).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Transaction>().HasOne<Wallet>().WithMany().HasForeignKey(p => p.WalletIdFk).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Transaction>().HasOne<Currency>().WithMany().HasForeignKey(p => p.CurrencyIdFk).OnDelete(DeleteBehavior.NoAction);
        
    }
}