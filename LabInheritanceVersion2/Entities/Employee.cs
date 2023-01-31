using System;
using System.Collections.Generic;
using System.IO;
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
        // 
        /// <summary>
        /// CreateList argument: takes in a string which is the file path
        /// </summary>
        public static List<Employee> CreateList(string filePath)
        {
            //create empty list to add in all people in the file 
            List<Employee> employeesList = new List<Employee>();
            
            //put file into a string array so that each string can be further split into 
            //the field values we want. e.g. id, name, addres,...
            string[]  fileArray = File.ReadAllLines(filePath);
            
        
            // on each line in the file array, split the string by : to separate field values
            // and store in another array for referencing later
            // this foreach loop essentially goes through each line in the file and converts the info
            // into the field values making up an employee (salary, parttime, waged)
            foreach (string line in fileArray)
            {
                string[] fieldValues = line.Split(':');

                // allocate values
                string currentId = fieldValues[0];
                string currentName = fieldValues[1];
                string currentAddress = fieldValues[2];

                // need to determine if this current line (aka person) is  (salary, parttime, waged)
                // salaried if 1st digit of id is between 0 and 4 inclusive
                // part-time if 1st digit of id is between 8 and 9 inclusive
                // waged if 1st digit is btwn 5 and 7 inclusive

                string firstIdDigit = currentId.Substring(0, 1);
                // string above needs to be int for comparison in if-else consdition
                int idDigit = int.Parse(firstIdDigit);

                if (idDigit >= 0 && idDigit <= 4)
                {
                    // salaried
                    string salary = fieldValues[7];
                    double salaryDouble = double.Parse(salary);

                    // create current line info  to a salaried employee
                    Salaried salariedEmployee = new Salaried(currentId, currentName, currentAddress, salaryDouble);
                    employeesList.Add(salariedEmployee);
                    
                }
                else if (idDigit >= 5 && idDigit <= 7)
                {
                    // wage
                    string rate = fieldValues[7];
                    string hours = fieldValues[8];
                    double rateDouble = double.Parse(rate);
                    PartTime waged = new PartTime(currentId, currentName, currentAddress, rateDouble);
                    employeesList.Add(waged);

                }
                else if (idDigit >= 8 && idDigit <= 9)
                {
                    //part-time
                    string rate = fieldValues[7];
                    string hours = fieldValues[8];

                    double rateDouble = double.Parse(rate);
                    PartTime partTime = new PartTime(currentId, currentName, currentAddress, rateDouble);
                    employeesList.Add(partTime);
                }

            }// end of foreach loop

            // test:
            //foreach(Employee employee in employeesList)
            //{
            //    Console.WriteLine(employee.ID + " " + employee.Name+ " " + employee.Address);
            //}


            return employeesList;
        }//end of CreateList method



        //Calculate and return the average weekly pay for all employees.
        public static double ComputeAveWeeklyPay(List<Employee> list)
        {
            double aveWeeklyPay=0;
            return aveWeeklyPay;
        }
        //Calculate and return the highest weekly pay for the wage employees, including the name of the employee.
        //Calculate and return the lowest salary for the salaried employees, including the name of the employee.

        //What percentage of the company’s employees fall into each employee category?

    }
}
