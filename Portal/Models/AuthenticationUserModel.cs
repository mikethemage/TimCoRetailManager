using System.ComponentModel.DataAnnotations;

namespace Portal.Models;

public class AuthenticationUserModel
{
    [Required(ErrorMessage="Email Address is requied.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is requied.")]
    public string Password { get; set; }
}
