using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace S3_Birk_Repitition
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppFunc function = new AppFunc();
        public MainWindow()
        {
            
            //Version 0.1
            InitializeComponent();
            dtgRides.ItemsSource = function.GetRideList();

            //Ride testRide = new Ride(400, "test", "testRutsjebane", "Nedbrud");
            //Report testReport = new Report("Nebrud", DateTime.Now, "Test", testRide);
            //testRide.Reports.Add(testReport);
            //tbkRideBreakdowns.Text = testRide.Breakdowns.ToString();
        }

        //Selection change for dtgRides
        private void dtgRides_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Set Ride name textblock
            tbkRideName.Text = (dtgRides.SelectedItem as Ride).Name;
            //Set Ride category textblock
            tbkRideCategory.Text = (dtgRides.SelectedItem as Ride).Category;
            //Set Ride status textblock
            tbkRideStatus.Text = (dtgRides.SelectedItem as Ride).Status;
            //Set Ride breakdowns textblock
            //tbkRideBreakdowns.Text = (dtgRides.SelectedItem as Ride).Breakdowns.ToString();
        }

        private void btnAddNewRide_Click(object sender, RoutedEventArgs e)
        {
            NewRideWindow openWindow = new NewRideWindow(function);
            openWindow.Owner = this;
            openWindow.Show();
            this.Hide();
        }

        private void btnAddNewRaport_Click(object sender, RoutedEventArgs e)
        {
            if (dtgRides.SelectedItem == null)
            {

            }
            else
            {
                NewReportWindow openWindow = new NewReportWindow(function, dtgRides.SelectedItem as Ride);
                openWindow.Owner = this;
                openWindow.Show();
                this.Hide();
            }
            
        }

        private void btnSeeRaport_Click(object sender, RoutedEventArgs e)
        {
            ReportsOverviewWindow openWindow = new ReportsOverviewWindow(function);
            openWindow.Owner = this;
            openWindow.Show();
            this.Hide();
        }

        private void btnSearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (tbxSearchBar == null)
            {
                dtgRides.ItemsSource = function.GetRideList();
            }
            else
            {
                List<Ride> searchList = new List<Ride>();
                foreach (Ride ride in dtgRides.Items)
                {
                    if (ride.Name.ToUpper() == tbxSearchBar.Text.ToUpper())
                    {
                        searchList.Add(ride);
                    }
                }
                dtgRides.ItemsSource = searchList;
            }
            
        }
    }
}
