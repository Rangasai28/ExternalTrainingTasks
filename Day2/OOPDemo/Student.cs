/*Student.cs
 * The below program declares student class  fields,Properties,Methods
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo
{
    public  class Student
    {
        //Declaring the Fields
        private string _studentName;
        private string _standard;
        private int _rollNum;
        private int _age;
        private char _gender;
        private float _height;
        private long _contactNumber;
        private bool _IsFeePending;

        // Student Name  Read/Write Property
        public string studentName
        {
            get { return _studentName; }
            set { _studentName = value; }
        }

        //Student Standard  Read/Write Property
        public string standard
        {
            get { return _standard; }
            set { _standard = value; }
        }

        //Student RollNum Read/Write Property
        public int rollNum
        {
            get { return _rollNum; }
            set { _rollNum = value; }
        }


        //Student Age Read/Write Property
        public int age
        {
            get { return _age; }
            set { _age = value; }
        }

        //Student Gender Read/Write Property
        public char gender
        {
            get { return _gender; }
            set { _gender = value; }
        }


        //Student Height Read/Write Property
        public float height
        {
            get { return _height; }
            set { _height = value; }
        }

        //student ContactNumber Read/Write Property
        public long contactNumber
        {
            get { return _contactNumber; }
            set { _contactNumber = value; }
        }

        //student FeeStaus Read/Write Property
        public bool IsFeePending
        {
            get { return _IsFeePending; }
            set { _IsFeePending = value; }
        }
        //Defining Two  Methods One that assign the values to the fields and other that Display details to the Console.
        public void fillStudentInfo(string Sname, string Sstandard, int SrollNum, int Sage, char Sgender, float Sheight, long ScontactNumber,bool SfeeStatus)
        {
            studentName = Sname;
            standard = Sstandard;
            rollNum = SrollNum;
            age = Sage;
            gender = Sgender;
            height = Sheight;
            contactNumber = ScontactNumber;
            IsFeePending = SfeeStatus;
        }


       
        public string displayStudentDetails()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Name  = {0}{1}", _studentName, Environment.NewLine);
            sb.AppendFormat("Standard  = {0}{1}", standard, Environment.NewLine);
            sb.AppendFormat("RollNumber  = {0}{1}", _rollNum, Environment.NewLine);
            sb.AppendFormat("Age  = {0}{1}", _age, Environment.NewLine);
            sb.AppendFormat("Gender  = {0}{1}", _gender, Environment.NewLine);
            sb.AppendFormat("Height  = {0}{1}f", _height, Environment.NewLine);
            sb.AppendFormat("ContactNumber  = {0}{1}", _contactNumber, Environment.NewLine);
            sb.AppendFormat("Is Fee Pending = {0}{1}", _IsFeePending, Environment.NewLine);

            return sb.ToString();

        }
    }
}
