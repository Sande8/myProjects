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

namespace SecondWPFApplication
{
    /// <summary>
    /// Interaction logic for Adminpage.xaml
    /// </summary>
    public partial class Adminpage : Window
    {
        public Adminpage()
        {
            InitializeComponent();
        }

        private void btnAddTenant_Click(object sender, RoutedEventArgs e)
        {
            Addtenant adduser = new Addtenant();
            adduser.Show();
            this.Close();
        }

        private void btnMakePayment_Click(object sender, RoutedEventArgs e)
        {
            MainWindow dashboard = new MainWindow();
            dashboard.Show();
            this.Close();
        }
    }
}
