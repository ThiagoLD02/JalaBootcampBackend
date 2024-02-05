using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WalletAPI.Components;
using WalletAPI.DTO;

namespace WalletAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WalletDbController : ControllerBase
{

    private static readonly DatabaseContext ctx;
    private readonly WalletRepository _walletRepository = new WalletRepository(ctx);
    
    private readonly Wallet<Currency> _wallet = new();
    private readonly string[] _currencies = ["Euro","Dollar"];
    
    [HttpGet]
    public IActionResult CreateWallet()
    {
        
        return Ok(_walletRepository.CreateWallet());
    }
    
    
    [HttpGet]
    public IActionResult GetWallet()
    {
        
        return Ok(_wallet.GetFoundsAsObject());
    }

    [HttpGet] // Is there a way to list the possible values on swagger?
    public IActionResult ConvertFounds(string currency)
    {
        var found = _currencies.FirstOrDefault(c => c == currency);
        if(found == null)
            return BadRequest("Specified currency not found!");
        var response = found == _currencies[0] ? _wallet.ExchangeToDollar() : _wallet.ExchangeToEuro();
        return Ok("Founds converted successfully!");
    }

    [HttpPost]
    public IActionResult AddFounds([FromBody] WalletAddCurrencyDto walletAddCurrencyDto)
    {
        if (walletAddCurrencyDto.Amount <= 0)
            return BadRequest("Amount must be grater than 0.");
        
        // This is wrong -> if(_currencies.FirstOrDefault(walletAddCurrencyDto.currency) == null)
        // Why do I need to create the arrow function? If I dont do so, it will return the first element
        if(_currencies.FirstOrDefault(c => c == walletAddCurrencyDto.Currency) == null)
            return BadRequest("Specified currency not found!");
        
        _wallet.AddFounds(walletAddCurrencyDto);
        
        return Ok("Founds added successfully");
    }
}
