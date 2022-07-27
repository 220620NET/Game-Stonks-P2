using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess;

public class StonksDbContext : DbContext
{
    public StonksDbContext() : base() { }

    public StonksDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users {get;set;}
}