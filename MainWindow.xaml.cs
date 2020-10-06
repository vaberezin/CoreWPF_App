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
using CoreWpfApp.TimerModule;
using System.Threading;
using System.Net.Http;
using Microsoft.EntityFrameworkCore.Internal;

namespace CoreWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         public MainWindow()
        {            
            InitializeComponent();
        }

        
        
        private void ButtoRainFlowCalcBtn_Click(object sender, RoutedEventArgs e){
           
           RainFlowCalcWindow rainFlowCalc = new RainFlowCalcWindow();
           rainFlowCalc.Show();
           
        }
        PomoTimer pt = new PomoTimer();
        public void TimerBtn_Click(object sender, RoutedEventArgs e)
        {
            
            Thread thread = new Thread(new ParameterizedThreadStart(pt.workTimer));
            thread.Start(this);
            
        }

        public void Work(){
            Thread thread = new Thread(new ParameterizedThreadStart(pt.workTimer));
            thread.Start(this);
        }

        private void PlitkaApp_Closed(object sender, EventArgs e)
        {
            this.Dispatcher.InvokeShutdown();
        }

        private void RegulationsBtn_Click(object sender, RoutedEventArgs e)
        {
            //Thread thread2 = new Thread(new ParameterizedThreadStart(pt.restTimer));
            //thread2.Start(this);
        }

        private void WorkingText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //code from api returning the string which the present content changes on
            string resultString;
            string PATH = "http://localhost:54504/";

            
                using (var client = new HttpClient())
                {
                    
                    var response = client.GetAsync(PATH + "/Api/Timer");
                    string _resultstr = response.Result.Content.ReadAsStringAsync().Result;
                    resultString = _resultstr;
                }
            
            if (resultString != "")
            {
                WorkingText.Text = resultString;
            }
            else
            {
                WorkingText.Text = "Произошла ошибка";
            }



        }
    }
}
