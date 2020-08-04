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

        int workInterval = 25; //default value
        int restInterval = 5; //default value

        public string RestLeft = "default";
        //public string WorkLeft = "default";
        

        int sleepSecond = 1000;

        DateTime MinTime = new DateTime(0001,01,01,00,00,00);
        

        internal void restTimer(object mainWindow)
        { //this method must be performed In RESTWINDOW window
            DateTime RestIntervalLeft = MinTime.AddMinutes(restInterval); //00:05:00
            MainWindow main = (MainWindow)mainWindow;
            RestWindow rw = main.restWindow;
            rw.Show();
            
            
            
            while (MinTime <= RestIntervalLeft)
            {
                RestIntervalLeft = RestIntervalLeft.AddSeconds(-1);
                main.Dispatcher.BeginInvoke(() =>
                {
                    rw.RestTextBlock.Text = RestIntervalLeft.ToString("T");
                });

                Thread.Sleep(sleepSecond);        //wait 1 second        
            }
            //actions after 'while':
            //if button"продолжить работу" pressed, resttime left should be added to the next resttime. window closed. method worktimerAsync runs.

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
                Thread.Sleep(10);
            }


            //wait 1 second  

            if (MinTime == WorkIntervalLeft)
            {
                restTimer(main);

            }

            


        }
    }
}
