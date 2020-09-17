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
using CoreWpfApp;
using CoreWpfApp.TimerModule;
using System.Threading;



namespace CoreWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RestWindow : Window
    {
        PomoTimer pt = new PomoTimer();
        public RestWindow()
        {
            InitializeComponent();
            
        }
        
        private void ContinueWorkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Thread thread = new Thread(new ParameterizedThreadStart(pt.restTimer));
            thread.Start(this);

        }
    }
}
