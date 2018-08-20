using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3_Birk_Repitition
{
    /// <summary>
    /// Interacts with the data layer(AppData) and handles the data it gets from there.
    /// </summary>
    public class AppFunc
    {
        //Source
        AppData data = new AppData();

        //GET
        //Get Ride list
        /// <summary>
        /// Gets a list of all rides from the database
        /// </summary>
        /// <returns>List<Ride></returns>
        public List<Ride> GetRideList()
        {
            return data.GetRideWithReportsList();
        }
        
        //Get Report list
        /// <summary>
        /// Gets a list of all reports from the database
        /// </summary>
        /// <returns>List<Report></returns>
        public List<Report> GetReportList()
        {
            return data.GetReportList();
        }

        //Get Category list
        /// <summary>
        /// Gets the list of possible categories and returns it in the form of a string list
        /// </summary>
        /// <returns>List<string></returns>
        public List<string> GetCategoryList()
        {
            List<string> list = new List<string>();
            list.Add("Rutsjebane");
            list.Add("Vandforlystelse");
            list.Add("Pendulforlystelse");
            return list;
        }

        //Get status list
        /// <summary>
        /// Gets the list of possible statuses and returns it in the form of a string list
        /// </summary>
        /// <returns>List<string></returns>
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
        /// <summary>
        /// Adds a Ride to the database
        /// </summary>
        /// <param name="ride"></param>
        public void AddRide(Ride ride)
        {
            data.AddRide(ride);
        }

        //Add report to databse
        /// <summary>
        /// Adds a report to the database
        /// </summary>
        /// <param name="report"></param>
        public void AddReport(Report report)
        {
            data.AddReport(report);
        }

        //EDIT
        //Edit Ride category
        /// <summary>
        /// Edits a Ride category
        /// </summary>
        /// <param name="ride"></param>
        /// <param name="status"></param>
        public void EditRideStatus(Ride ride, string status)
        {
            data.EditRideStatus(ride, status);
        }
    }
}
