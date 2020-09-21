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

        private void RegulationsBtn_Click(object sender, RoutedEventArgs e)
        {
            RegulationWindow regWin = new RegulationWindow();
            regWin.Owner = this;
        }
    }
}
