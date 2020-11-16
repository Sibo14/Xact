using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

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

                string query = "Select name, dm.address1, smf.Stock_Description, dtf.Transaction_Type from Debtors_Master dm, INVOICE_HEADER ih, STOCK_MASTER_FILE smf, INVOICE_DETAIL id, DEBTORS_TRANSACTION_FILE dtf" +
                    " where dm.Account_Code = @Account_Code AND smf.Stock_Code = id.Stock_Code AND id.Invoice_No = ih.Invoice_No AND dtf.Account_Code = dm.Account_Code";

                SqlCommand cmd = new SqlCommand(query, sqlCon);

                cmd.Parameters.AddWithValue("@Account_Code", int.Parse(tbAccount.Text));

                SqlDataReader da = cmd.ExecuteReader();

                while (da.Read())
                {
                    lblName.Content = da.GetValue(0).ToString();
                    lblAddress1.Content = da.GetValue(1).ToString();
                    label6.Content = da.GetValue(2).ToString();
                    lblTransaction.Content = da.GetValue(3).ToString();
                }

                sqlCon.Close();
            }

        }
    }
}