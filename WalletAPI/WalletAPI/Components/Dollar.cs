namespace WalletAPI.Components;

public class Dollar: Currency
{

    public Dollar(double amount)
    {
        this.Amount = amount;
        this.Name = "Dollar";
        this.EquivalentValue = 0.92d;
        
    }
    
    public override double Convert()
    {
        /*
         * 1 dol = 0.92 eu
         * x dol = y eu
         * y = x*0.92
         */
        return this.Amount * this.EquivalentValue;
    }

}