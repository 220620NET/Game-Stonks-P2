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
}