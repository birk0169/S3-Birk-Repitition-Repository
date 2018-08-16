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
using System.Windows.Shapes;

namespace S3_Birk_Repitition
{
    /// <summary>
    /// Interaction logic for NewReportWindow.xaml
    /// </summary>
    public partial class NewReportWindow : Window
    {
        AppFunc function;
        Ride ride;
        public NewReportWindow(AppFunc function, Ride ride)
        {
            InitializeComponent();
            this.function = function;
            this.ride = ride;
            tbkSelectedRide.Text = ride.Name;
            cbxReportStatus.ItemsSource = function.GetStatusList();
        }

        private void NewReport_Closed(object sender, EventArgs e)
        {
            Owner.Show();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSaveAndClose_Click(object sender, RoutedEventArgs e)
        {
            //Validates input
            if (cbxReportStatus.SelectedItem == null)
            {
                tbkErrorMessage.Text = "Du skal vælge en status for at oprette raporten";
            }
            else if (!DateTime.TryParse(dpReportDate.Text, out DateTime n))
            {
                tbkErrorMessage.Text = "Datoen er ikke gyldig";
            }
            else
            {
                

                try
                {
                    Report report = new Report(cbxReportStatus.SelectedItem.ToString(), DateTime.Parse(dpReportDate.Text), tbxReportNotes.Text, ride);
                    function.EditRideStatus(ride, report.Status);
                    function.AddReport(report);
                    this.Close();
                }
                catch
                {
                    tbkErrorMessage.Text = "Noget gik galt";


                }
            }
        }
    }
}
