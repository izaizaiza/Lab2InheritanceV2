using LabInheritanceVersion2.Entities;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;

namespace LabInheritanceVersion2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // for some reason the default looks for the txt file inside the Debug folder
            // ==> added a copy of the txt file there
            string path = "employees.txt";

            // a. Fill a list with objects based on the supplied data file.
            List<Employee> employees = Employee.CreateList(path);

            // make a sublist of employees
            List<Salaried> salariedEmployees = new List<Salaried>();
            List<PartTime> partTimeEmployees = new List<PartTime>();
            List<Wages> wagesEmployees = new List<Wages>();

            foreach (Employee employee in employees)
            {
                string idString = employee.ID.ToString().Substring(0,1);
                int firstDigit = int.Parse(idString);
                if (firstDigit>=0 && firstDigit<=4)
                {
                    // add the employee to the salaried sublist
                }
            }
            // should i just do this in the CreateList method?
            // and return a list of list(s)?

            // b. Calculate and return the average weekly pay for all employees.


            // c. Calculate and return the highest weekly pay for the wage employees,
            //including the name of the employee



            // d. Calculate and return the lowest salary for the salaried employees,
            // including their name.


            Salaried.FindLowestPaid(salariedEmployees);


            // e. what percentage of the company's employees fall into each employee
            // category?


        }//end of main
    }
}
