/*
 * studentInherit.cs
 * Demonstration of Concept Inheritance
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo
{
    public class studentInherit : Person  //Inheriting from the class Person
    {
        //Declaring Fields
        private string _standard;
        private int _rollNum;
        private float _height;


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

        //Student height Read/Write Property
        public float height
        {
            get { return _height; }
            set { _height = value; }
        }

        public static void Main(string[] args)
        {
            //Creating studentOne object of class studentInherit
            studentInherit studentOne = new studentInherit();


            //Assigning values to the Fields of studentOne Object
            studentOne.name = "Bala";
            studentOne.standard = "Seventh";
            studentOne.rollNum = 35;
            studentOne.age = 11;
            studentOne.gender = 'M';
            studentOne.height = 4.3f;
            studentOne.contactNumber = 9475692434;


            //Displaying The Field Values
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} ", studentOne.name, studentOne.standard, studentOne.rollNum, studentOne.age, studentOne.gender, studentOne.height, studentOne.contactNumber);

        }
    }
}
