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
            List<Employee> employees = new List<Employee>();
            
            // for some reason the default looks for the txt file inside the Debug folder
            // ==> added a copy of the txt file there
            string path = "employees.txt";
            

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] cells = line.Split(':');

                string id = cells[0];
                string name = cells[1];
                string address = cells[2];

                // get the id and its first digit
                string firstDigit = id.Substring(0, 1);

                int firstDigitInt = int.Parse(firstDigit);

                if (firstDigitInt >= 0 && firstDigitInt <= 4)
                {
                    // salaried
                    string salary = cells[7];

                    double salaryDouble = double.Parse(salary);
                    Salaried salaried = new Salaried(id, name, address, salaryDouble);
                    employees.Add(salaried);
                }
                else if (firstDigitInt >= 5 && firstDigitInt <= 7)
                {
                    // wage
                    string rate = cells[7];
                    string hours = cells[8];
                }
                else if (firstDigitInt >= 8 && firstDigitInt <= 9)
                {
                    //part-time
                    string rate = cells[7];
                    string hours = cells[8];

                    double rateDouble = double.Parse(rate);
                    PartTime parttime = new PartTime(id, name, address, rateDouble);
                    employees.Add(parttime);
                }

                
         

            }// end of foreach loop

            //some che3cking

            foreach(Employee employee in employees)
            {
                Console.WriteLine(employee.Name);
            }


        }//end of main
    }
}
