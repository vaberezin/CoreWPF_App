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
using CoreWpfApp.RainCalcs; //����������111





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

            //binding.ElementName = "F_tot";
            //binding.Path = new PropertyPath("Text");
            //F_tot.SetBinding()

            RainVariables rainVariables = new RainVariables();
                
            
            
        }
        List<string> Regions = ListForCombobox.getRegionList();
        List<string> Places = ListForCombobox.getPlaceList();

        
        

        void SetValuesFromComboboxes(RainVariables rainVariables)
        {
            rainVariables.F = Double.Parse(F_tot.Text);
            rainVariables.F_road = Double.Parse(F_road.Text);
            rainVariables.F_roof = Double.Parse(F_roof.Text);
            rainVariables.F_gravel = Double.Parse(F_shcheb.Text);
            rainVariables.F_green = Double.Parse(F_grass.Text);
            rainVariables.Q_20 = Int32.Parse(RainIntensivity.Text);
            rainVariables.P = Double.Parse(RainPossibility.Text);
            rainVariables.t_con = Double.Parse(ConcentrationTime.Text);
            rainVariables.l_lotok = Double.Parse(LotokLength.Text);
            rainVariables.v_lotok = Double.Parse(LotokVelocity.Text);
            rainVariables.l_p = Double.Parse(CollectorLength.Text);
            rainVariables.v_p = Double.Parse(CollectorVelocity.Text);
            rainVariables.N_sections = Int32.Parse(SectionsNumber.Text);
            rainVariables.n = 
            rainVariables.A();
            rainVariables.Psy_mid();
            rainVariables.Z_mid();
            rainVariables.t_r();
            rainVariables.t_can();
            rainVariables.t_p();

            //Target VALUES:->
            rainVariables.Q_rRain();
            rainVariables.Q_rIce();
            rainVariables.Q_cal();
            //Target VALUES<-:


            rainVariables.beta =;
            rainVariables.m_r;
            rainVariables.gamma;
            rainVariables.K;
            rainVariables.Z_i;
            rainVariables.Psy_i;
            rainVariables.h_c;
            //rainVariables.t_c; later, not for MVP
            rainVariables.K_y();
            rainVariables.F_y() ;
            rainVariables.F_roadRoof() ;
            


        }

        double getA(RainVariables rainVariables){
            double _A = 0;

            _A = rainVariables.Q_20 * Math.Pow(20, rainVariables.n)*Math.Pow((1+(Math.Log10(rainVariables.P)/Math.Log10(rainVariables.m_r))), rainVariables.gamma);

            return _A;

        }

        double getPsy_mid(RainVariables rainvariables){
            double _Psy_mid = 0; 

            _Psy_mid = 
              
            return _Psy_mid;
        }
        

    }
}
