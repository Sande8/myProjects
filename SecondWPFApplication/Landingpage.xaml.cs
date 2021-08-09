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
    /// Interaction logic for Landingpage.xaml
    /// </summary>
    public partial class Landingpage : Window
    {
        public Landingpage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Loginscreen loginpage = new Loginscreen();
            loginpage.Show();
            this.Close();
            
        }
    }
}
