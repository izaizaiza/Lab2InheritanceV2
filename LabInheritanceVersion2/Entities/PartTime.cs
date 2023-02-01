using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabInheritanceVersion2.Entities
{
    internal class PartTime : Employee
    {
        //field
        private double rate;
        private double hours;

        //properties
        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public double Hours
        {
            get { return hours; }
            set { hours = value; }
        }


        //constructors

        public PartTime(string theid, string thename, string theaddress, double therate, double thehours)
        {
            ID = theid;
            Name = thename;
            Address = theaddress;
            Rate = therate;
            Hours = thehours;
        }

        public PartTime(string theid, string thename, string theaddress, string thephone, long thesin)
        {
            ID = theid;
            Name = thename;
            Address = theaddress;
            string phone = thephone;
            long sin = thesin;
        }


        //methods

        //public static double WeeklyPay(PartTime)
        //{
        //    double weeklyPay;

        //    // 2 parts of computation: 1, compute the pay of the hours less than 40. 2, compute the overtime and then add together
        //    weeklyPay = ((PartTime.Rate *Hours) + (Rate * (Hours - 40) * 1.5));
        //    return weeklyPay;
        //}

        
    }//end of PartTime Class
}
