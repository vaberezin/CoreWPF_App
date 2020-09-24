using CoreWpfApp.AppDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CoreWpfApp
{
    
    public partial class RegulationWindow : Window
    {

        IEnumerable<Regulation> RegulationList;


        public RegulationWindow()
        {
            InitializeComponent();
            getList();
            
            VKRegsList.ItemsSource = RegulationList;
        }

        void getList()
        {
            RegulationsModel RModel = new RegulationsModel();
            RegulationList = RModel._getRegulations;
        }
    }
}
