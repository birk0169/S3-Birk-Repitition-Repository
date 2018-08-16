using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3_Birk_Repitition
{
    public class Ride
    {
        //Fields
        private int id;
        private List<Report> reports;
        private string name;
        private string category;
        private string status;

        public Ride(string name, string category)
        {
            Id = -1;
            Name = name;
            Category = category;
            Status = "Virker";
        }

        //Constructors
        public Ride(int id, string name, string category, string status)
        {
            Id = id;
            Name = name;
            Category = category;
            Status = status;
        }

        //Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public string Status { get => status; set => status = value; }
        internal List<Report> Reports { get => reports; set => reports = value; }
        //public int Breakdowns { get { return GetNumberOfBreakdowns(); } }
        //public int DaysSinceLastBreakdown { get => daysSinceLastBreakdown; set => daysSinceLastBreakdown = value; }

        //Methods
        //private int GetNumberOfBreakdowns()
        //{
        //    int rideBreakdowns = 0;
        //    foreach (Report reportItem in Reports)
        //    {
                
        //        if (reportItem.Status == "Nedbrud")
        //        {
        //            rideBreakdowns++;
        //        }
        //    }
        //    return rideBreakdowns;
        //}
    }
}
