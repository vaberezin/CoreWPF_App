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
        private int restInterval = 5; //default value
        private int Second = 1000;

        public string RestLeft = "default";
        //public string WorkLeft = "default";

        DateTime MinTime = new DateTime(0001, 01, 01, 00, 00, 00);


        internal void restTimer(object rwind)   //this method must be performed In RESTWINDOW window
        {
            RestWindow rwin = rwind as RestWindow;
            DateTime RestIntervalLeft = MinTime.AddSeconds(restInterval); //00:00:30
            //MainWindow main = mainWindow as MainWindow;
            
            //RestWindow rwin = new RestWindow();            
            //rwin.Show();
            //rwin.Owner = main;


            while (MinTime < RestIntervalLeft)
            {
                RestIntervalLeft = RestIntervalLeft.AddSeconds(-1);

                rwin.Dispatcher.BeginInvoke(() =>
                {
                    rwin.RestTextBlock.Text = RestIntervalLeft.ToString("T");
                });
                Thread.Sleep(Second);        //wait 1 second     


                if (MinTime == RestIntervalLeft) // 0 seconds of work left
                {
                    rwin.Dispatcher.BeginInvoke(() =>
                    {
                        rwin.RestTextBlock.FontSize = 40;
                        rwin.RestTextBlock.Text = "Отдых закончен, пора и поработать!";    
                        
                    });
                }

                //actions after 'while':
                //if button"продолжить работу" pressed, resttime left should be added to the next resttime. window closed. method worktimer runs.

            }
        }

        internal void workTimer(object mainWindow)
        {
            DateTime WorkIntervalLeft = MinTime.AddMinutes(workInterval); //00:25:00
            MainWindow main = (MainWindow)mainWindow;

            while (MinTime < WorkIntervalLeft)
            {
                WorkIntervalLeft = WorkIntervalLeft.AddSeconds(-1);

                Application.Current.Dispatcher.BeginInvoke(() =>
                {
                    main.WorkingTimeTxtBlock.Text = WorkIntervalLeft.ToString("T");
                });
                //wait 1 second  
                Thread.Sleep(1);
            }


            if (MinTime == WorkIntervalLeft) // 0 seconds of work left
            {



                main.Dispatcher.BeginInvoke(() =>
                {
                    main.WorkingTimeTxtBlock.Text = $"0:{workInterval}:00";
                    RestWindow rwin = new RestWindow();
                    rwin.Show();
                });
                                
            }

            


        }
    }
}
