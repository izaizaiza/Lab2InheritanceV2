using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabInheritanceVersion2.Entities
{
    internal class Employee
    {
        //field
        private string id;
        private string name;
        private string address;

        //properties
        public string ID 
        { 
            get{ return id; }
            set{ id = value; }
        }

        public string Name 
        {
            get { return name; }
            set { name = value; }
        }
        

        public string Address 
        {
            get { return address; }
            set { address = value; }
        }

        //constructors
        public Employee() { }

        public Employee(string theid, string thename, string theaddress, string thephone)
        {
            ID= theid;
            Name= thename;
            Address= theaddress;
            string phone = thephone;
        }

        // methods
        //Fill a list with objects based on the supplied data file.
        //Calculate and return the average weekly pay for all employees.
        //Calculate and return the highest weekly pay for the wage employees, including the name of the employee.
        //Calculate and return the lowest salary for the salaried employees, including the name of the employee.

        //What percentage of the company’s employees fall into each employee category?

    }
}
