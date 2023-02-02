using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LabInheritanceVersion2.Entities
{
    /// <summary>
    ///  this class represents an employee that is paid by salary
    /// <remarks> Author: Iza Lumpio</remarks>
    /// <remarks> Date:  Feb 2, 2023 </remarks>
    /// </summary>
    internal class Salaried : Employee
    {
        //field
        private double salary;

        //properties
        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        //constructors
        public Salaried(string theid, string thename, string theaddress, double thesalary)
        {
            ID = theid;
            Name = thename;
            Address = theaddress;
            Salary = thesalary;
        }

        public Salaried(string theid, string thename, string address, string thephone, long thesin)
        {
            ID = theid;
            Name = thename;
            Address = address;
            string phone = thephone;
            long sin = thesin;
        }


        //methods



    }// end of Salaried class
}
