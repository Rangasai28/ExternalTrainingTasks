using System.ComponentModel.DataAnnotations;
using WebApiDTOsDemo.Attibutes;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace WebApiDTOsDemo.Models;

public class StudentDtoPost
{
    [Required(ErrorMessage = "First Name is required")]
    [StringLength(10, MinimumLength = 3, ErrorMessage = "First Name should be between 3 and 10 characters")]
    public string FirstName { get; set; }

    public string? MiddleName { get; set; }

    [Required(ErrorMessage = "Last Name is required")]
    [StringLength(10, MinimumLength = 3, ErrorMessage = "Last Name should be between 3 and 10 characters")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Full Name is required")]
    [StringLength(10, MinimumLength = 3, ErrorMessage = "Last Name should be between 3 and 10 characters")]

    public string FullName { get; set; }

    
    public char Gender { get; set; }

    public DateOnly DateOfBirth { get; set; }

    [StringLength(60)]
    public string Address { get; set; }

    [Phone]
    public string Phone { get; set; }

    public string GuardianName { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    [StrongPassword]
    public string Password { get; set; }

}
