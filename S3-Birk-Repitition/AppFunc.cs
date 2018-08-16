using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3_Birk_Repitition
{
    public class AppFunc
    {
        //Source
        AppData data = new AppData();

        //GET
        //Get Ride list
        public List<Ride> GetRideList()
        {
            return data.GetRideList();
        }
        
        //Get Report list
        public List<Report> GetReportList()
        {
            return data.GetReportList();
        }

        //Get Category list
        public List<string> GetCategoryList()
        {
            List<string> list = new List<string>();
            list.Add("Rutsjebane");
            list.Add("Vandforlystelse");
            list.Add("Pendulforlystelse");
            return list;
        }

        //Get status list
        public List<string> GetStatusList()
        {
            List<string> list = new List<string>();
            list.Add("Virker");
            list.Add("Mangler service");
            list.Add("Nedbrud");
            return list;
        }

        //ADD
        //Add ride to database
        public void AddRide(Ride ride)
        {
            data.AddRide(ride);
        }

        //Add report to databse
        public void AddReport(Report report)
        {
            data.AddReport(report);
        }

        //EDIT
        //Edit Ride category
        public void EditRideStatus(Ride ride, string status)
        {
            data.EditRideStatus(ride, status);
        }
    }
}
