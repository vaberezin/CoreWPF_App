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
using CoreWpfApp.RainCalculation;
using System.Windows.Data.Bindings;




namespace CoreWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RainFlowCalcWindow : Window
    {
        public RainFlowCalcWindow()
        {
            
            InitializeComponent();
            Region.ItemsSource = Regions;
            Place.ItemsSource = Places;
            RainVariables Rv = new RainVariables();
            
            
        }
        List<string> Regions = ListForCombobox.getRegionList();
        List<string> Places = ListForCombobox.getPlaceList();

        
        //Bindings https://metanit.com/sharp/wpf/11.php

        Binding binding = new Binding();
        binding.


    }
}
