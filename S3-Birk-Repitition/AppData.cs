using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static S3_Birk_Repitition.DataSetRideService;
using S3_Birk_Repitition.DataSetRideServiceTableAdapters;

namespace S3_Birk_Repitition
{
    public class AppData
    {
        DataSetRideService dataset = new DataSetRideService();
        TableAdapterManager AdapterManager = new TableAdapterManager();

        //GET
        //Get Ride list
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

        //FIND
        //Find ride by id
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
