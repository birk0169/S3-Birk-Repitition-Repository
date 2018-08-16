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
    /// Interaction logic for NewRideWindow.xaml
    /// </summary>
    public partial class NewRideWindow : Window
    {
        AppFunc function;
        public NewRideWindow(AppFunc function)
        {
            InitializeComponent();
            this.function = function;
            cbxCategory.ItemsSource = function.GetCategoryList();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //Opens main window if this window is closed
            Owner.Show();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSaveAndClose_Click(object sender, RoutedEventArgs e)
        {
            //Validates input
            if (tbxRideName.Text == null)
            {
                tbkErrorMessage.Text = "Du skal give forlystelsen et navn før du kan oprette den";
            }
            else if (cbxCategory.SelectedItem == null)
            {
                tbkErrorMessage.Text = "Du skal vælge en kategori før du kan oprette en forlystelse";
            }
            else
            {
                try
                {
                    
                    Ride ride = new Ride(tbxRideName.Text, cbxCategory.SelectedItem.ToString());
                    //Adds ride to database
                    function.AddRide(ride);
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
