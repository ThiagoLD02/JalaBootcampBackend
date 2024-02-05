using System.ComponentModel.DataAnnotations;

namespace WalletAPI.Components;

public class WalletModel
{
    [Key]
    public int WalletId { get; set; }

    public double Dollars { get; set; } 
    public double Euros { get; set; }
    
}