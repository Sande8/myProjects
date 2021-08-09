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
using System.Windows.Shapes;

namespace SecondWPFApplication
{
    /// <summary>
    /// Interaction logic for Addtenant.xaml
    /// </summary>
    public partial class Addtenant : Window
    {
        public Addtenant()
        {
            InitializeComponent();
        }

        private void btnAddTenant_Click(object sender, RoutedEventArgs e)
        {
           SqlConnection sqlcon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WPFLognDB;Integrated Security=True");
            try
            {
                
                string query = "INSERT INTO Tenant (tenID,tenName,tenSurname,tenPhone,tenAddress,tenRoomNum,tenGender) VALUES(@tenID,@tenName,@tenSurname,@tenPhone,@tenAddress,@tenRoomNum,@tenGender)";
                SqlCommand sqlcom = new SqlCommand(query, sqlcon);
                sqlcom.CommandType = System.Data.CommandType.Text;
                sqlcom.Parameters.AddWithValue("@tenID", txtTenIDNum.Text);
                sqlcom.Parameters.AddWithValue("@tenName", txtTenName.Text);
                sqlcom.Parameters.AddWithValue("@tenSurname", txtTenSurname.Text);
                sqlcom.Parameters.AddWithValue("@tenPhone", txtTenPhone.Text);
                sqlcom.Parameters.AddWithValue("@tenAddress", txtTenAddress.Text);
                sqlcom.Parameters.AddWithValue("@tenRoomNum", txtTenRoomNumb.Text);
                if (rb1.IsChecked == true)
                {
                    sqlcom.Parameters.AddWithValue("@tenGender", "Male");
                }else if (rb2.IsChecked == true)
                {
                    sqlcom.Parameters.AddWithValue("@tenGender", "Female");
                }
                
                sqlcon.Open();
                sqlcom.ExecuteNonQuery();
                MessageBox.Show("Records Inserted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
            Adminpage admin = new Adminpage();
            admin.Show();
            this.Close();
        }
    }
}
