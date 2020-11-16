using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace Xact
{
    /// <summary>
    /// Interaction logic for DebtorsMaster.xaml
    /// </summary>
    public partial class DebtorsMaster : Window
    {
        string connectionString = ConfigurationManager.ConnectionStrings["TestString"].ConnectionString;
        public DebtorsMaster()
        {
            InitializeComponent();
            //opening db using string from app.config
         
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {


            //validation

            SqlConnection sqlCon = new SqlConnection(connectionString);
           

                sqlCon.Open();


                //insertition of data into database
                string query = " Insert into Debtors_Master ([Name],[Address1],[Address2],[Address3]) Values ('" + tbName.Text + "','" + tbAdd1.Text + "','" + tbAdd2.Text + "','" + tbAdd3.Text + "')";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();

                //open new window
               Window1 main = new Window1();
                main.Show();
                this.Close();
           
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //open new window
            Window1 main = new Window1();
            main.Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //open new window
            DebtorsTransaction main = new DebtorsTransaction();
            main.Show();
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Invoice_Header main = new Invoice_Header();
            main.Show();
            this.Close();
        }
    }
}