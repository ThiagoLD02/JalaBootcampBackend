namespace WalletAPI.Components;

public class WalletRepository : IWalletRepository
{

    private readonly DatabaseContext _context;
    private static int _id = 0;

    public WalletRepository(DatabaseContext ctx)
    {
        _context = ctx;
    }
    
    public WalletModel CreateWallet()
    {
        var wallet = new WalletModel
        {
            WalletId = ++_id,
            Dollars = 0.0d,
            Euros = 0.0d
        };

        _context.Add(wallet);
        _context.SaveChanges();
        return wallet;


    }

    public WalletModel GetWallet(int id)
    {
        var response = _context.Events.FirstOrDefault(w => w.WalletId == id);

        if (response == null)
            throw new FileNotFoundException();
        return response;
    }

    public WalletModel AddFounds(int id, string currency, double amount)
    {
        var wallet = GetWallet(id);
        if (currency == "Dollar")
            wallet.Dollars += amount;
        else
            wallet.Euros += amount;

        _context.SaveChanges();
        return wallet;
    }

    private double Exchange(double amount, string fromCurrency)
    {
        const double dollarEquivalentValue = 0.92d;
        const double euroEquivalentValue = 1.09d;
        double exchanged;
        
        if (fromCurrency == "Dollar")
        {
            exchanged = amount * euroEquivalentValue;
        }
        else
        {
            exchanged = amount * dollarEquivalentValue;
        }

        return exchanged;
    }

    public WalletModel ExchangeFounds(int id, string fromCurrency)
    {
        var wallet = GetWallet(id);
        if (fromCurrency == "Dollar")
            wallet.Euros = Exchange(wallet.Dollars, fromCurrency);
        else
            wallet.Dollars += Exchange(wallet.Euros, fromCurrency);

        _context.SaveChanges();
        return wallet;
    }

    public WalletModel WithdrawFounds(int id, string currency)
    {
        var wallet = GetWallet(id);
        if (currency == "Dollar")
            wallet.Dollars = 0d;
        else
            wallet.Euros = 0d;
        
        _context.SaveChanges();
        return wallet;
    }

}



























