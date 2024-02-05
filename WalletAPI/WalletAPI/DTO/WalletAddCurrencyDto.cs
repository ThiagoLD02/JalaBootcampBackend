namespace WalletAPI.DTO;

public class WalletAddCurrencyDto
{
    public required double Amount { get; set; }
    public required string Currency { get; set; }
}