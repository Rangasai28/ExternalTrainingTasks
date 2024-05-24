/*
 * Person.cs
 * This Program Defines Common attributes of a Person.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo
{
    public  class Person
    {   
        //Declaration Of Fields
        private string _name;
        private int _Id;
        private int _age;
        private char _gender;
        private long _contactNumber;
       
        //Declaration of Properties
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        
        public int age
        {
            get { return _age; }
            set { _age = value; }
        }

        public char gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public long contactNumber
        {
            get { return _contactNumber; }
            set { _contactNumber = value; }
        }

    }
}
