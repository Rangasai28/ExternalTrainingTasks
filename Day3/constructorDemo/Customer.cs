using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constructorDemo
{
    public  class Customer
    {
        private string name;
        private long number;
        private string city;
        public Customer(string name,long number,string city) 
        {
            this.name = name;
            this.number = number;
            this.city = city;
        }

        public string getCustomerDetails()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Customer Name  = {0}{1}", name, Environment.NewLine);
            sb.AppendFormat("Customer Number  = {0}{1}", number, Environment.NewLine);
            sb.AppendFormat("Customer City  = {0}{1}", number, Environment.NewLine);

            return sb.ToString();

        }
    }
}
