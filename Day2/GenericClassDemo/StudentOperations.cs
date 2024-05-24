using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassDemo
{
    internal class StudentOperations
    {
        static MemberList<Student> student = new MemberList<Student>();
        public  void Addstudent()
        {
            Student s1 = new Student(101, "Bala", 22, 878778, "Fourth", "ECE");
            Student s2 = new Student(102, "Ranga", 32, 478778, "Fourth", "ECE");
            Student s3 = new Student(103, "Ranga", 32, 478778, "Fourth", "CSE");

            //Adding Student Members  into List
            student.AddMember(s1);
            student.AddMember(s2);
            student.AddMember(s3);
        }
        public  void removeStudent()
        {
           List<Student> list = student.getMemberDetails();
            int id = Person.getId();
            foreach (Student s in list)
            {
                if (s.Id == id)
                {
                    student.RemoveMember(student.mem.IndexOf(s));
                    return;
                }
            }
        }

        public  void updateStudent()
        {
            Student newstudent = new Student();
            newstudent.Branch = "EDC";
            newstudent.Name = "Ravula";
            newstudent.Year = "Fourth";
            newstudent.Age = 22;
            newstudent.ContactNumber = 9898879;
            int id = Person.getId();
            foreach (Student s in student.mem)
            {
                if (s.Id == id)
                {
                    s.ContactNumber = newstudent.ContactNumber;
                    s.Name = newstudent.Name;
                    s.Branch = newstudent.Branch;
                    s.Year = newstudent.Year;
                    s.Age = newstudent.Age;
                }
            }
        }
        public  void getStudentDetails()
        {
            int id = Person.getId();
            foreach (Student member in student.mem)
            {
                if (member.Id == id)
                {
                    Console.WriteLine(member.getDetails());
                    return;
                }

            }
        }
    }
}
