/*
 * studentDetails.cs
 * This Program demonstrates initialization of class fields in three Different Approaches
 * 1.Creating an Object and Initializing.
 * 2.Definig Methods That Assign values to the Fields .
 */

using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace OOPDemo
{   
    /// <summary>
    /// After Executing this program It displays Details of the Student to The Console
    /// </summary>
    public class studentDetails
    {   
       
        static void Demo1()
        {
            Student studentOne = new Student();
            studentOne.studentName = "Bala";
            studentOne.standard = "Fifth";
            studentOne.rollNum = 05;
            studentOne.age = 11;
            studentOne.gender = 'M';
            studentOne.height = 4.3f;
            studentOne.contactNumber = 9475692434;
            studentOne.IsFeePending = false;

            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", studentOne.studentName, studentOne.standard, studentOne.rollNum, studentOne.age, studentOne.gender, studentOne.height, studentOne.contactNumber, studentOne.IsFeePending);

        }

        static void Demo2()
        {
            Student studentTwo = new Student();

            Console.WriteLine("Enter Student Name:");
            studentTwo.studentName = Console.ReadLine();

            Console.WriteLine("Enter Student Standard:");
            studentTwo.standard = Console.ReadLine();

            Console.WriteLine("Enter Student RollNumber:");
            studentTwo.rollNum = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Student Age:");
            studentTwo.age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Student Gender:");
            studentTwo.gender = Convert.ToChar(Console.ReadLine());


            Console.WriteLine("Enter Student Height:");
            studentTwo.height = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Enter Student Contact Number:");
            studentTwo.contactNumber = Convert.ToInt64(Console.ReadLine());


            Console.WriteLine("Enter Student Fee Status:");
            studentTwo.IsFeePending = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine(studentTwo.displayStudentDetails());

        }

        static void Demo3()
        {
            Student studentThree = new Student();
            studentThree.fillStudentInfo("Ranga", "Sixth", 18, 12, 'M', 4.3f, 9564752576, false);


            //Displaying the studentThree details to the Console using the Method displayStudentDetails().
            Console.WriteLine(studentThree.displayStudentDetails());
           
        }

        static void Main(string[] args)
        {
           studentDetails.Demo1();
           studentDetails.Demo2();
           studentDetails.Demo3();
        }
    }
}
