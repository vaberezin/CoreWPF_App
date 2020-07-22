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
using MySqlX.XDevAPI.Common;

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
            getA(rainVariables); //+
            getPsy_mid(rainVariables);+
            getZ_mid();
            gett_r();
            gett_can();
            gett_p();

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

            double K_gravel = rainvariables.F_gravel * 0.4; //tabl10 rek
            double K_road = rainvariables.F_road * 0.95; //tabl10 rek
            double K_roof = rainvariables.F_roof * 0.95; //tabl10 rek
            double K_green = rainvariables.F_green * 0.1; //tabl10 rek


            _Psy_mid = (K_gravel + K_green + K_road + K_roof) / rainvariables.F;

            return _Psy_mid;
        }
        
        double getZ_mid(RainVariables rainvariables)
        {
            double _Z_mid = 0;

            double K_gravel = rainvariables.F_gravel * 0.125; //tabl10 rek
            double K_road = rainvariables.F_road * //; //tabl10 rek
            double K_roof = rainvariables.F_roof * //; //tabl10 rek
            double K_green = rainvariables.F_green * 0.038; //tabl10 rek



            return _Z_mid;
        }

        double z_roadAndRoof(RainVariables rainVariables)
        {
             
            bool getN = n_065(rainVariables.n);

            double A_prev = 0;              //get this! by Linq.
            double A_next = 0;              //get this! by Linq.

            double z_Aprev = 0;             //get this! by Linq.
            double z_A_next = 0;            //get this! by Linq.

            double deltaMain = (A_next - A_prev) / (z_A_next - z_Aprev);
            double diff = rainVariables.A - A_prev;

            double InterpolationResult = z_Aprev + deltaMain * diff;

            return InterpolationResult;
        }

        //method for z_roadAndRoof
        bool n_065(double _n)
        {
            if (_n < 0.65)
                return true;
            else
                return false;
        }
    }
}
