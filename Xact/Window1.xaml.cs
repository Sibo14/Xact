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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        string connectionString = ConfigurationManager.ConnectionStrings["TestString"].ConnectionString;
        public Window1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            //validation

            SqlConnection sqlCon = new SqlConnection(connectionString);


            sqlCon.Open();


            //insertition of data into database
            string query = " Insert into STOCK_MASTER_FILE ([Stock_Description],[Cost],[Selling_Price],[Qty_Purchased]) Values ('" + tbStockDesc.Text + "','" + Decimal.Parse(tbCost.Text) + "','"+ Decimal.Parse(tbSelling.Text)+"','" + int.Parse(tbPurch.Text) + "','" + int.Parse(tbSold.Text) + "')";

            //logic for calculations
            string query1 = "SELECT Qty_Purchased*Cost AS Total_Purchases_Excl_Vat , Qty_Purchased-Qty_Sold AS Stock_On_Hand, Qty_Sold*Selling_Price AS Total_Sales_Excl_Vat  FROM STOCK_MASTER_FILE";

            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.ExecuteNonQuery();

            //open new window
            Window1 main = new Window1();
            main.Show();
            this.Close();


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //open new window to next page
            Window2 main = new Window2();
            main.Show();
            this.Close();
        }
    }
}
