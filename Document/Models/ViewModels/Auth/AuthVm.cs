using System.ComponentModel.DataAnnotations;

namespace Document.Models.ViewModels.Auth;

public class AuthVm
{
    [Required]
    public string Phone { get; set; }

    [Required]
    public string Password { get; set; }
}