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
    /// Interaction logic for Invoice_Header.xaml
    /// </summary>
    public partial class Invoice_Header : Window
    {

        string connectionString = ConfigurationManager.ConnectionStrings["TestString"].ConnectionString;
       
        public Invoice_Header()
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

            sqlCon.Open();

            string query1 = "Select date, transaction_type from Stock_Transaction_File where Account_Code= @Account_Code";


            SqlCommand cmd1 = new SqlCommand(query1, sqlCon);

            cmd1.Parameters.AddWithValue("@Account_Code", int.Parse(tbAccount.Text));

            SqlDataReader da1 = cmd1.ExecuteReader();


            while (da1.Read())
            {
                lblDate.Content = da1.GetValue(0).ToString();
                lblTransDate.Content = da1.GetValue(1).ToString();
                lblTransaction.Content = da1.GetValue(2).ToString();
            }

             sqlCon.Close();
        }
    }
}
