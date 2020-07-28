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

namespace CoreWpfApp.TimerModule
{
    public class PomoTimer
    {

        int workInterval = 25; //default value
        int restInterval = 5; //default value

        public string RestLeft = "";
        public string WorkLeft = "";


        int sleepSecond = 1000;

        DateTime MinTime = new DateTime(0001,01,01,00,00,00);        
        
        
        void restTimer(){ //this method must be performed In RESTWINDOW window
            DateTime RestIntervalLeft = MinTime.AddMinutes(restInterval); //00:05:00
            while (MinTime <= RestIntervalLeft)
            {
                RestIntervalLeft.AddSeconds(-1);
                string WorkLeftShow = RestIntervalLeft.ToString("D");
                
                //xaml разметка textbox.text = restLeftShow;

                Thread.Sleep(sleepSecond);        //wait 1 second        
            }
            //actions after 'while':
            //if button"продолжить работу" pressed, resttime left should be added to the next resttime. window closed. method worktimerAsync runs.
        }

        void workTimer(){
            DateTime WorkIntervalLeft = MinTime.AddMinutes(workInterval); //00:25:00
            while (MinTime <= WorkIntervalLeft)
            {
                WorkIntervalLeft.AddSeconds(-1);
                string WorkLeftShow = WorkIntervalLeft.ToString("D");
                //xaml разметка textbox.text = WorkLeftShow;

                Thread.Sleep(sleepSecond);        //wait 1 second  

            if(MinTime == WorkIntervalLeft)      {
                    //actions after 'while': see below in this block

                RestWindow restWindow = new RestWindow();                
                
                restWindow.Show();
                restTimerAsync(); //method runs once restwindow has been shown.
                
                }
            }
            
        }


        public async void workTimerAsync(){
            
            {
                await(Task.Run(()=>workTimer()));
            }
        }

        public async void restTimerAsync(){
            
            {
                await(Task.Run(()=>restTimer()));
            }
        }
    }
}
