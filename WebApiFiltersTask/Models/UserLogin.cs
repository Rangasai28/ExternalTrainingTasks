using System.ComponentModel.DataAnnotations;

namespace WebApiFiltersTask.Models;

public class UserLogin
{
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
