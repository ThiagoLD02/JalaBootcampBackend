using WalletAPI.Components;

namespace WalletAPI;

public class Euro : Currency
{
    public Euro(double amount)
    {
        this.Amount = amount;
        this.Name = "Euro";
        this.EquivalentValue = 1.09d;
    }

    public override double Convert()
    {
        /*
         * 1 eu = 1.09 dol
         * x eu = y dol
         * y = x*1.09
         */
        return this.Amount * this.EquivalentValue;
    }

}