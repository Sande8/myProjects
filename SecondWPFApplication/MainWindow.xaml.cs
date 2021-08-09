using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace SecondWPFApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSubmitPayment_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Payment submited");
            Adminpage admin = new Adminpage();
            admin.Show();
            this.Close();
        }

        private void btnIDsearch_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WPFLognDB;Integrated Security=True");
            sqlcon.Open();
            SqlCommand command = new SqlCommand("SELECT tenID, tenName, tenSurname, tenPhone, tenAddress, tenRoomNum FROM Tenant WHERE tenID=@tenID", sqlcon);
            command.Parameters.AddWithValue("@tenID", txtIDsearch.Text);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                txtidnumb.Text = dr.GetValue(0).ToString();
                txtname.Text = dr.GetValue(1).ToString();
                txtsurname.Text = dr.GetValue(2).ToString();
                txtphonenumb.Text = dr.GetValue(3).ToString();
                txtaddress.Text = dr.GetValue(4).ToString();
                txtroomnumb.Text = dr.GetValue(5).ToString();
            }
            sqlcon.Close();
        }
    }
}
