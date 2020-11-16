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
    /// Interaction logic for DebtorsTransaction.xaml
    /// </summary>
    public partial class DebtorsTransaction : Window
    {


        string connectionString = ConfigurationManager.ConnectionStrings["TestString"].ConnectionString;
        public DebtorsTransaction()
        {
            InitializeComponent();

            lblDate.Content = DateTime.Now.ToString();
        }

        private void tbAccount_TextChanged(object sender, TextChangedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);


            sqlCon.Open();

            if (tbAccount.Text != "")
            {


                string query = "Select name, address1 from Debtors_Master where Account_Code= @Account_Code";
               

                // SELECT Orders.OrderID, Customers.CustomerName, Orders.OrderDate
                // FROM Orders
                // INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID;

                SqlCommand cmd = new SqlCommand(query, sqlCon);
               

                cmd.Parameters.AddWithValue("@Account_Code", int.Parse(tbAccount.Text));
               
                SqlDataReader da = cmd.ExecuteReader();
                

                while (da.Read())
                {
                    lblName.Content = da.GetValue(0).ToString();
                    lblAddress1.Content = da.GetValue(1).ToString();
                }

                sqlCon.Close();
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection sqlCon = new SqlConnection(connectionString);


            sqlCon.Open();
            string query1 = " Insert into Debtors_Transaction_File ([Account_Code],[Date],[Transaction_Type]) Values ('" + tbAccount.Text + "','" + DateTime.Parse(lblDate.Content.ToString()) + "','" + comboBox.Text + "' )";

             SqlCommand sqlc = new SqlCommand(query1, sqlCon);
            SqlDataReader dr = sqlc.ExecuteReader();
        }
        
    }
}
