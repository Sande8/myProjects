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
    /// Interaction logic for Loginscreen.xaml
    /// </summary>
    public partial class Loginscreen : Window
    {
        public Loginscreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WPFLognDB;Integrated Security=True");
            try
            {
                if (sqlcon.State == System.Data.ConnectionState.Closed)
                    sqlcon.Open();
                string query = "SELECT COUNT(1) FROM tblUser WHERE Username=@Username AND Userpassword=@Userpassword";
                SqlCommand sqlcom = new SqlCommand(query, sqlcon);
                sqlcom.CommandType = System.Data.CommandType.Text;
                sqlcom.Parameters.AddWithValue("@Username", txtUsername.Text);
                sqlcom.Parameters.AddWithValue("@Userpassword", txtPassword.Password);
                int count = Convert.ToInt32(sqlcom.ExecuteScalar());
                if (count == 1)
                {
                    Adminpage dashboard = new Adminpage();
                    dashboard.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }

        }
    }
}
