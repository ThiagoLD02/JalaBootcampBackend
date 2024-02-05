using WalletAPI.Components;
using WalletAPI.DTO;

namespace WalletAPI;

public class Wallet<T> where T : Currency
{
    private  Dollar _dollar = new(0d);
    private  Euro _euro = new(0d);
    private readonly string[] _currencies = ["Euro","Dollar"];
    
    public Wallet(T currency)
    {
        AddToWallet(currency);
    }
    public Wallet(){}
    
    private void AddToWallet(T currency)
    {
        if (currency.Name == "Dollar")
        {
            _dollar.Amount += currency.Amount;
            
        }
        else
        {
            _euro.Amount += currency.Amount;
        }
    }
    
    private void AddToWallet(double amount, string currency)
    {
        if (currency == "Dollar")
        {
            _dollar.Amount += amount;
            
        }
        else
        {
            _euro.Amount += amount;
        }
    }
    
    public void AddFounds(WalletAddCurrencyDto walletAddCurrencyDto)
    {
        foreach (var currency in _currencies)
        {
            if (currency == walletAddCurrencyDto.Currency)
            {
                AddToWallet(walletAddCurrencyDto.Amount,walletAddCurrencyDto.Currency);
                
            }
        }
    }

    public string GetFoundsAsString()
    {
        return $"You have {_dollar.Amount} dollars and {_euro.Amount} euros.";
    }
    
    public DoubleStringFoundsDto[] GetFoundsAsObject()
    {
        var dollar = new DoubleStringFoundsDto(_dollar.Amount, _dollar.Name);
        var euro = new DoubleStringFoundsDto(_euro.Amount, _euro.Name);

        return [dollar, euro];

    }

    public double ExchangeToDollar()
    {
        var amount = _euro.Convert();
        _dollar.Amount += amount;
        _euro.Amount = 0d;
        return _dollar.Amount;
    }
    public double ExchangeToEuro()
    {
        var euroAmount = _dollar.Convert();
        _euro.Amount += euroAmount;
        _dollar.Amount = 0d;
        return _euro.Amount;
    }
    
    
}

public class DoubleStringFoundsDto(double amount, string name)
{
    public double Amount { get; set; } = amount;
    public string Name { get; set; } = name;
   
}




































