using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LabInheritanceVersion2.Entities
{
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

        //Calculate and return the lowest salary for the salaried employees, including their name
        public static string FindLowestPaid(List<Salaried> list)
        {
            // let the lowest pay to be the first pay in the in the list and compare as you
            //go through the foreach loop

            double lowestPay = list[0].Salary;
            string lowestPaidName = list[0].Name;
            

            foreach (Salaried salaried in list)
            {
                if(salaried.Salary < lowestPay)
                {
                    lowestPay = salaried.Salary;
                    lowestPaidName = salaried.Name;
                }
           
            }
            
            return "The salaried employee with the lowest salary is " + lowestPaidName + " with a salary of " + lowestPay;
        }


    }// end of Salaried class
}
