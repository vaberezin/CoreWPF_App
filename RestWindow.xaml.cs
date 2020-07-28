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



namespace CoreWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RestWindow : Window
    {
        PomoTimer pomoTimer1 = new PomoTimer();
        RestTextBlock.Text = pomoTimer1.RestLeft;
        public RestWindow()
        {
            InitializeComponent(); 
            pomoTimer1.restTimerAsync();   
                   
        }
        
        private void ContinueWorkButton_Click(object sender, RoutedEventArgs e){
            this.Close();
            
        }
               
    }
}
