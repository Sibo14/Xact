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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Xact
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer introTime = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            introTime.Interval = TimeSpan.FromSeconds(3);
            introTime.Tick += new EventHandler(introTime_Tick);
            introTime.Start();


        }

        void introTime_Tick(object sender, EventArgs e)
        {
            DebtorsMaster dm = new DebtorsMaster();
            dm.Show();
            introTime.Stop();
            this.Close();
            
        }
    }
}
