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

                    // create a new salary employee using the current line info
                    Salaried salariedEmployee = new Salaried(currentId, currentName, currentAddress, salaryDouble);
                    employeesList.Add(salariedEmployee);
                    

                    
                }
                else if (idDigit >= 5 && idDigit <= 7)
                {
                    // wage
                    string rate = fieldValues[7];
                    string hours = fieldValues[8];
                    double rateDouble = double.Parse(rate);
                    double hoursDouble = double.Parse(hours);

                    Wages waged = new Wages(currentId, currentName, currentAddress, rateDouble, hoursDouble); //
                    employeesList.Add(waged);
                    

                }
                else if (idDigit >= 8 && idDigit <= 9)
                {
                    //part-time
                    string rate = fieldValues[7];
                    string hours = fieldValues[8];

                    double rateDouble = double.Parse(rate);
                    double hoursDouble = double.Parse(hours);

                    PartTime partTime = new PartTime(currentId, currentName, currentAddress, rateDouble, hoursDouble);
                    employeesList.Add(partTime);
                    
                }


            }// end of foreach loop

            // test to see if each employee has the corresponding employee class (salaried, parttime, wages):
            //foreach(Employee employee in employeesList)
            //{
            //    Console.WriteLine(employee.ID + " " + employee.Name+ " " + employee.Address);
            //    Console.WriteLine(employee.GetType());
            //}

            return employeesList;
        }//end of CreateList method



        //Calculate and return the average weekly pay for all employees.
        public static double ComputeAveWeeklyPay(List<Employee> list)
        {
            double aveWeeklyPay;
            double accumWeeklyPay=0;
            foreach (Employee employee in list)
            {
                if (employee is Salaried)
                {
                    //convert back to salary class to access Salary property
                    Salaried salariedEmployee = (Salaried)employee;

                    accumWeeklyPay += salariedEmployee.Salary;
                }
                else if (employee is Wages)
                {
                    // convert back to Wages class to access rate and hours
                    Wages wageEmployee = (Wages)employee;

                    if (wageEmployee.Hours < 40)
                    {
                        accumWeeklyPay += (wageEmployee.Rate* wageEmployee.Hours);
                    }
                    else
                    {
                        // 2 parts of computation: 1, compute the pay of the hours less than 40. 2, compute the overtime and then add together
                        accumWeeklyPay += ((wageEmployee.Rate * 40) + (wageEmployee.Rate * 1.5 * (wageEmployee.Hours-40)) ) ;
                    }
                    
                }
                else
                {
                    PartTime partTimeEmployee = (PartTime)employee;
                    // part timers do not have overtime pay so 
                    accumWeeklyPay += (partTimeEmployee.Rate * partTimeEmployee.Hours);
                }

            }// end of foreach loop

            aveWeeklyPay = accumWeeklyPay / list.Count;
            return aveWeeklyPay;
        }// end of ComputeAveWeeklyPay


        //Calculate and return the highest weekly pay for the wage employees, including the name of the employee.
        public static string WagedHighestPaid(List<Employee> list)
        {
            double highestWeeklyPay = 0;
            double weeklyPay;
            string wagedName = "name";

            foreach (Employee employee in list)
            {
                if (employee is Wages)
                {
                    // turn employee to Wages class to access hours and rate
                    Wages wageEmployee = (Wages)employee; 
                    
                    //first determine weekly pay of this employee
                    if (wageEmployee.Hours < 40)
                    {
                        weeklyPay = (wageEmployee.Rate * wageEmployee.Hours);
                    }
                    else
                    {
                        // 2 parts of computation: 1, compute the pay of the hours less than 40. 2, compute the overtime and then add together
                        weeklyPay = (wageEmployee.Rate * 40) + (wageEmployee.Rate * 1.5 * (wageEmployee.Hours - 40));
                    }

                    //compare weeklypay to minWeeklyPay
                    if(weeklyPay > highestWeeklyPay)
                    {
                        highestWeeklyPay = weeklyPay;
                        wagedName= wageEmployee.Name;
                    }


                }
            }
            return wagedName + " is the highest paid waged employee with a weekly pay of $" + highestWeeklyPay;
        }


        //Calculate and return the lowest salary for the salaried employees, including the name of the employee.
        public static string SalariedLowestPaid(List<Employee> list)
        {
            double lowestSalary;
            string salariedName;

            // make a list for salary and a corresponding list for who it belongs to
            List<double> salariesList = new List<double>();
            List<string> salariedNamesList = new List<string>();

            foreach (Employee employee in list)
            {
                if (employee is Salaried)
                {
                    // turn employee to Salaried class to access salary
                    Salaried salariedEmployee = (Salaried)employee;
                    salariesList.Add(salariedEmployee.Salary);
                    salariedNamesList.Add(salariedEmployee.Name);
                    
                }
            }

            // compare the salariesList values
            lowestSalary = salariesList[0];
            salariedName = salariedNamesList[0];
            for (int i=0; i<salariesList.Count; i++)
            {
                if (salariesList[i] < lowestSalary)
                {
                    lowestSalary= salariesList[i];
                    salariedName= salariedNamesList[i];
                }
            }

            return salariedName + " is the lowest paid salaried employee with a weekly pay of $" + lowestSalary;
        }



        //What percentage of the company’s employees fall into each employee category?

    }
}
