using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GenericClassDemo
{
    public class Student : Person
    {
       // public static MemberList<Student> memberList;
        public string Year { get; set; }

        public string Branch { get; set; }

        public Student()
        {

        }
        public Student(int id, string name, int age, int number, string year, string branch)
        {
            Id = id;
            Name = name;
            Age = age;
            ContactNumber = number;
            Year = year;
            Branch = branch;

        }
        public override string getDetails()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Id  = {0}{1}", Id, Environment.NewLine);
            sb.AppendFormat("Name  = {0}{1}", Name, Environment.NewLine);
            sb.AppendFormat("Age  = {0}{1}", Age, Environment.NewLine);
            sb.AppendFormat("Year  = {0}{1}", Year, Environment.NewLine);
            sb.AppendFormat("Branch  = {0}{1}f", Branch, Environment.NewLine);
            sb.AppendFormat("ContactNumber  = {0}{1}", ContactNumber, Environment.NewLine);
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }

        
       
    }
}
