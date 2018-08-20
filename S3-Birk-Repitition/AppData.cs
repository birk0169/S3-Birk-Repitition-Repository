using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static S3_Birk_Repitition.DataSetRideService;
using S3_Birk_Repitition.DataSetRideServiceTableAdapters;

namespace S3_Birk_Repitition
{
    /// <summary>
    /// Interacts with the sql database and either gets data or adds data to it. 
    /// </summary>
    public class AppData
    {
        DataSetRideService dataset = new DataSetRideService();
        TableAdapterManager AdapterManager = new TableAdapterManager();

        //GET
        //Get Ride list
        /// <summary>
        /// Loads the rides from the database and then coverts it into a Ride list which it returns
        /// </summary>
        /// <returns>List<Ride></returns>
        public List<Ride> GetRideList()
        {
            RidesDataTable rideRows = new RidesDataTable();
            AdapterManager.RidesTableAdapter.Fill(rideRows);

            List<Ride> list = new List<Ride>();
            foreach (RidesRow row in rideRows)
            {
                Ride ride = new Ride(row.Id, row.Name, row.Catagory, row.Status);
                list.Add(ride);
            }
            return list;
        }

        //Get Report list
        /// <summary>
        /// Loads the reports from the database and coverts it into a Report list which it then returns
        /// </summary>
        /// <returns>List<Report></returns>
        public List<Report> GetReportList()
        {
            ReportsDataTable reportRows = new ReportsDataTable();
            AdapterManager.ReportsTableAdapter.Fill(reportRows);

            List<Report> list = new List<Report>();
            foreach (ReportsRow row in reportRows)
            {
                Report report = new Report(row.Status, row.ReportTime, row.Notes, FindRideById(row.RideId));
                list.Add(report);
            }
            return list;
        }

        //Get ride with reports
        /// <summary>
        /// Goes through the Report list and adds the reports to the Ride list and then returns that list
        /// </summary>
        /// <returns>List<Ride> with its report property filled out</returns>
        public List<Ride> GetRideWithReportsList()
        {
            List<Ride> list = GetRideList();
            List<Report> reports = GetReportList();
            foreach (Ride ride in list)
            {

                foreach (Report report in reports)
                {
                    if (report.Ride.Id == ride.Id)
                    {
                        ride.AddReportToList(report);
                    }
                }
            }
            return list;
        }

        //FIND
        //Find ride by id
        /// <summary>
        /// Goes through the ride list to find a specific ride by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Ride</returns>
        private Ride FindRideById(int Id)
        {
            foreach (Ride ride in GetRideList())
            {
                if (ride.Id == Id)
                {
                    return ride;
                }
            }
            return null;
        }

        //ADD
        //Add ride
        /// <summary>
        /// Adds a Ride to the Rides table in the database
        /// </summary>
        /// <param name="ride"></param>
        public void AddRide(Ride ride)
        {
            RidesRow row = dataset.Rides.NewRidesRow();
            row.Name = ride.Name;
            row.Catagory = ride.Category;
            row.Status = ride.Status;
            ride.Id = AddRideRow(row);
        }
        private int AddRideRow(RidesRow row)
        {
            dataset.Rides.Rows.Add(row);
            AdapterManager.RidesTableAdapter.Update(dataset.Rides);
            return dataset.Rides.First().Id;
        }

        //Add Report
        /// <summary>
        /// Adds a Report to the Reports table in the database
        /// </summary>
        /// <param name="report"></param>
        public void AddReport(Report report)
        {
            ReportsRow row = dataset.Reports.NewReportsRow();
            row.Status = report.Status;
            row.ReportTime = report.Date;
            row.Notes = report.Notes;
            row.RideId = report.Ride.Id;
            report.Id = AddReportRow(row);
        }
        private int AddReportRow(ReportsRow row)
        {
            dataset.Reports.Rows.Add(row);
            AdapterManager.ReportsTableAdapter.Update(dataset.Reports);
            return dataset.Reports.First().Id;
        }

        //EDIT
        //Edit Ride in database
        public void EditRide(Ride ride, string name, string category, string status)
        {
            //Get database rows

            //Find the rows to edit

            //Update the row with edited data

            //Save changes
        }

        //Edit Ride status in database
        /// <summary>
        /// Edits the Ride status inside the database
        /// </summary>
        /// <param name="ride"></param>
        /// <param name="status"></param>
        public void EditRideStatus(Ride ride, string status)
        {
            //Get database rows
            RidesDataTable rideRows = new RidesDataTable();
            AdapterManager.RidesTableAdapter.Fill(rideRows);

            //Find the rows to edit
            RidesRow row = rideRows.FindById(ride.Id);

            //Update the row with edited data
            row.Status = status;

            //Save changes
            AdapterManager.RidesTableAdapter.Update(rideRows);
        }

        //DELETE

        //Adapter Manager
        public AppData()
        {
            AdapterManager.ReportsTableAdapter = new ReportsTableAdapter();
            AdapterManager.RidesTableAdapter = new RidesTableAdapter();
        }
    }
}
