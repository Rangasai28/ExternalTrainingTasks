using System.Collections.Generic;
namespace GenericClassDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
           StudentOperations studentOperations = new StudentOperations();
           StaffOperations staffOperations = new StaffOperations();
           
            studentOperations.Addstudent();
            studentOperations.getStudentDetails();

           
            studentOperations.updateStudent();
            studentOperations.getStudentDetails();
            studentOperations.removeStudent();
            studentOperations.getStudentDetails();

            staffOperations.Addstaff();
            staffOperations.getStaffDetails();
        }

    }
}
