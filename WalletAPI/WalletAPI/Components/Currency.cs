namespace WalletAPI.Components;


public abstract class Currency
{
    public double Amount { get; set; }
    public string Name { get; set; }
    protected double EquivalentValue { get; set; }
    public abstract double Convert();

}