using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.Library.Models;
public class CreateUserModel
{
    [Required]
    [DisplayName("First Name")]
    public string FirstName { get; set; }

    [Required]
    [DisplayName("Last Name")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [DisplayName("Email Address")]
    public string EmailAddress { get; set; }

    [Required]
    [DisplayName("Password")]
    public string Password { get; set; }

    [Required]
    [DisplayName("Confirm Password")]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
}
