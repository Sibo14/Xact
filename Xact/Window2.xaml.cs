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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        string connectionString = ConfigurationManager.ConnectionStrings["TestString"].ConnectionString;
        public Window2()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            


        }

        private void tbCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);


            sqlCon.Open();

            if (tbCode.Text!= "")
            {

            
            string query = "Select name, address1 from Debtors_Master where Account_Code= @Account_Code";
            SqlCommand cmd = new SqlCommand(query, sqlCon);

            cmd.Parameters.AddWithValue("@Account_Code", int.Parse(tbCode.Text));

            SqlDataReader da = cmd.ExecuteReader();

            while (da.Read())
            {
                lblName.Content = da.GetValue(0).ToString();
                lblAddress1.Content = da.GetValue(1).ToString();
            }

            sqlCon.Close();
        }

        }
    }
}
