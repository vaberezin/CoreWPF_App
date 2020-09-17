using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;
using CoreWpfApp;
using System.Windows.Threading;

namespace CoreWpfApp.TimerModule
{
    public class PomoTimer
    {

        private int workInterval = 25; //default value
        private int restInterval = 30; //default value
        private int Second = 1000;

        public string RestLeft = "default";
        //public string WorkLeft = "default";

        DateTime MinTime = new DateTime(0001, 01, 01, 00, 00, 00);


        internal void restTimer(object mainWindow)
        { //this method must be performed In RESTWINDOW window
            DateTime RestIntervalLeft = MinTime.AddSeconds(restInterval); //00:00:02
            MainWindow main = (MainWindow)mainWindow;
            

                //testing
                main.Dispatcher.BeginInvoke(() =>
                {
                    RestWindow rwin = new RestWindow();
                    rwin.Owner = main;
                    //rwin.Show();
                    
                    while (MinTime < RestIntervalLeft)
                {
                RestIntervalLeft = RestIntervalLeft.AddSeconds(-1);
                rwin.Dispatcher.BeginInvoke(() =>
                {
                    rwin.RestTextBlock.Text = RestIntervalLeft.ToString("T");
                });
                Thread.Sleep(3);        //wait 1 second     

                
                if(true){
                    int zzz = 1;
                }
                                  
            }
            //actions after 'while':
            //if button"продолжить работу" pressed, resttime left should be added to the next resttime. window closed. method worktimerAsync runs.


                });
                //testing


            

        }

        internal void workTimer(object mainWindow)
        {
            DateTime WorkIntervalLeft = MinTime.AddMinutes(workInterval); //00:25:00
            MainWindow main = (MainWindow)mainWindow;

            while (MinTime < WorkIntervalLeft)
            {
                WorkIntervalLeft = WorkIntervalLeft.AddSeconds(-1);

                main.Dispatcher.BeginInvoke(() =>
                {
                    main.WorkingTimeTxtBlock.Text = WorkIntervalLeft.ToString("T");
                });
                //wait 1 second  
                Thread.Sleep(3);
            }


            if (MinTime == WorkIntervalLeft) // 0 seconds of work left
            {

                
                main.Dispatcher.BeginInvoke(() =>
                {
                    restTimer(mainWindow);
                    
                });
                                
            }

            


        }
    }
}
