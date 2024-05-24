using System.ComponentModel.DataAnnotations;

namespace WebApiDTOsDemo.Models;

public class StudentDtoPut
{
    public string Address { get; set; }

    public string Phone { get; set; }

    [Required(ErrorMessage = "Is active status is required.")]
    public bool IsActive { get; set; }
}
