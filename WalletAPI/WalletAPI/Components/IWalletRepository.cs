namespace WalletAPI.Components;

public interface IWalletRepository
{
    public WalletModel CreateWallet();
    public WalletModel AddFounds(int id, string currency, double amount);
    public WalletModel GetWallet(int id);
    public WalletModel ExchangeFounds(int id, string fromCurrency);
    public WalletModel WithdrawFounds(int id, string currency);
}