using Microsoft.VisualBasic;

namespace WebApiAsyncAwaitDemo.Models
{
    public class StudentD
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public char Gender { get; set; }

        public DateFormat DateOfBirth { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string GuardianName { get; set; }

        public int DepartmentId { get; set; }

        public string CollegeName { get; set; } = "HYDERABAD UNIVERSITY";

        public DateTime AdmissionDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }
    }
}
