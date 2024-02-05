using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace WalletAPI;

public class WalletContext : DbContext
{
    public DbSet<WalletTable> Wallet { get; set; } 

    public string DbPath { get; }

    public WalletContext()
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "wallet.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseInMemoryDatabase($"Data Source={DbPath}");
}

public class WalletTable
{
    public int Id { get; set; }
    public double Amount { get; set; } = 0.0d;
    public string Currency { get; set; } = string.Empty;
}