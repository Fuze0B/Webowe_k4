using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Perfumy.Models;

public class Perfume
{
    public int Id { get; set; }

     [DisplayName("Marka perfumu")]
    [Required(ErrorMessage = "Pole jest wymagane")]
    public string? Brand { get; set; } // marka

      [DisplayName("Model perfumu")]
    [Required(ErrorMessage = "Pole jest wymagane")]
    public string? Model { get; set; } // nazwa

    [DisplayName("Zapach")]
    [Required(ErrorMessage = "Pole jest wymagane")]
    public string? Scent { get; set; } // np waniliowy czy jakis inny

    [DisplayName("Ilość(ml)")]
    [Required(ErrorMessage = "Pole jest wymagane")]
    public int? Amount { get; set; } // mililitry litry itd
}