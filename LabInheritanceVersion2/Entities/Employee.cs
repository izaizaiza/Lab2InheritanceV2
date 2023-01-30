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
    }
}
