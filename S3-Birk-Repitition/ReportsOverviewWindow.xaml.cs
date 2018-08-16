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
    /// Interaction logic for ReportsOverviewWindow.xaml
    /// </summary>
    public partial class ReportsOverviewWindow : Window
    {
        AppFunc function;
        public ReportsOverviewWindow(AppFunc function)
        {
            InitializeComponent();
            this.function = function;

            dtgReports.ItemsSource = function.GetReportList();

            //tbkName.Text = ride.Name;
            //tbkStatus.Text = ride.Name;
            //tbkReportDate.Text = ride.Name;
        }

        private void ReportsOverview_Closed(object sender, EventArgs e)
        {
            Owner.Show();
        }

        //Selection change
        private void dtgReports_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgReports.SelectedItem == null)
            {

            }
            else
            {
                tbkName.Text = (dtgReports.SelectedItem as Report).Ride.Name;
                tbkStatus.Text = (dtgReports.SelectedItem as Report).Status;
                tbkReportDate.Text = (dtgReports.SelectedItem as Report).Date.ToString();
                tbkNotes.Text = (dtgReports.SelectedItem as Report).Notes;
            }
        }
    }
}
