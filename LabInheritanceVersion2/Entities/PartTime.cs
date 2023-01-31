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

        //properties
        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }


        //constructors

        public PartTime(string theid, string thename, string theaddress, double therate)
        {
            ID = theid;
            Name = thename;
            Address = theaddress;
            Rate = therate;
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

        
    }//end of PartTime Class
}
