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
            /// <summary>
            ///  this will serve as the test sight/ implementation
            ///  area for the the classes in the Entities folder
            /// <remarks> Author: Iza Lumpio</remarks>
            /// <remarks> Date:  Feb 2, 2023 </remarks>
            /// </summary>
            /// 

            
            //add a copy of the txt file there
            string path = "employees.txt";
            // for some reason the default looks for the txt file inside the Debug folder

            // a. Fill a list with objects based on the supplied data file.
            List<Employee> employees = Employee.CreateList(path);


            // b. Calculate and return the average weekly pay for all employees.
            Console.WriteLine(Employee.ComputeAveWeeklyPay(employees));


            // c. Calculate and return the highest weekly pay for the wage employees,
            //including the name of the employee
            Console.WriteLine(Employee.WagedHighestPaid(employees));


            // d. Calculate and return the lowest salary for the salaried employees,
            // including their name.
            Console.WriteLine(Employee.SalariedLowestPaid(employees));


            // e. what percentage of the company's employees fall into each employee
            // category?
            Console.WriteLine(Employee.EmployeePercentage(employees));


        }//end of main
    }
}
