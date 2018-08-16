using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3_Birk_Repitition
{
    public class Report
    {
        //Fields
        private int id;
        private Ride ride;
        private string status;
        private DateTime date;
        private string notes;

        public Report(string status, DateTime date, string notes, Ride ride)
        {
            Id = -1;
            Status = status;
            Date = date;
            Notes = notes;
            Ride = ride;
        }

        //Properties
        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Notes { get => notes; set => notes = value; }
        internal Ride Ride { get => ride; set => ride = value; }
        public string Status { get => status; set => status = value; }
        
    }
}
