using Microsoft.EntityFrameworkCore;

namespace WalletAPI.Components;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){}
    
    public DbSet<WalletModel> Events { get; set; }
}