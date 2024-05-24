using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassDemo
{
    internal class StaffOperations
    {
        static MemberList<Staff> staff = new MemberList<Staff>();
        public  void Addstaff()
        {
            Staff st1 = new Staff(101, "Bala", 42, 878778, 20000m, "LabAssistent");
            Staff st2 = new Staff(102, "Ranga", 32, 878778, 30000m, "LabInCharge");
            Staff st3 = new Staff(103, "Ranga", 32, 878778, 30000m, "LabInCharge");

            //Adding Staff Members into the List
            staff.AddMember(st1);
            staff.AddMember(st2);
            staff.AddMember(st3);
        }
        public  void removeStaff()
        {
            int id = Person.getId();
            foreach (Staff s in staff.mem)
            {
                if (s.Id == id)
                {
                    staff.RemoveMember(staff.mem.IndexOf(s));
                    return;
                }
            }
        }

        public void updateStaff(Staff newStaff)
        {
            int id = Person.getId();
            foreach (Staff s in staff.mem)
            {
                if (s.Id == id)
                {
                    s.ContactNumber = newStaff.ContactNumber;
                    s.Name = newStaff.Name;
                    s.Salary = newStaff.Salary;
                    s.Department = newStaff.Department;
                    s.Age = newStaff.Age;
                }
            }
        }



        public void getStaffDetails()
        {
            int id = Person.getId();
            foreach (Staff member in staff.mem)
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
