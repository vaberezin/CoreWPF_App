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
using CoreWpfApp.RainCalcs;
using CoreWpfApp.AppDB;



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

                          
        }

        RainVariables rainVariables = new RainVariables();
        List<string> Regions = ListForCombobox.getRegionList();
        List<string> Places = ListForCombobox.getPlaceList();

            //FUUUUUUUCKK
        private void QrButton_Click  (object sender, RoutedEventArgs e){
           RainVariables rainVariables1 = rainVariables;
           SetValuesFromComboboxes(rainVariables1);
           decimal result = Q_rRain(rainVariables1);
           ResultTextValue.Text = result.ToString();
           
        }

        //METHOD TO ASSIGN input data to variables
        void SetValuesFromComboboxes(RainVariables rainVariables)
        {    
            rainVariables.F = decimal.Parse(F_tot.Text);
            rainVariables.F_road = decimal.Parse(F_road.Text);
            rainVariables.F_roof = decimal.Parse(F_roof.Text);
            rainVariables.F_gravel = decimal.Parse(F_shcheb.Text);
            rainVariables.F_green = decimal.Parse(F_grass.Text);
            rainVariables.Q_20 = Int32.Parse(RainIntensivity.Text);
            rainVariables.P = decimal.Parse(RainPossibility.Text);
            rainVariables.t_con = decimal.Parse(ConcentrationTime.Text);
            rainVariables.l_lotok = decimal.Parse(LotokLength.Text);
            rainVariables.v_lotok = decimal.Parse(LotokVelocity.Text);
            rainVariables.l_p = decimal.Parse(CollectorLength.Text);
            rainVariables.v_p = decimal.Parse(CollectorVelocity.Text);
            rainVariables.N_sections = Int32.Parse(SectionsNumber.Text);
            rainVariables.n = getN(rainVariables);
            rainVariables.A = (decimal)getA(rainVariables); //+
            rainVariables.Psy_mid = getPsy_mid(rainVariables); //+
            rainVariables.Z_mid = getZ_mid(rainVariables); //+
            rainVariables.t_r = gett_r(rainVariables);
            //gett_can(rainVariables); // enters to gett_r method
            //gett_p(rainVariables); // enters to gett_r method

            //Target VALUES:->
            rainVariables.Q_rRain = Q_rRain(rainVariables);
            rainVariables.Q_rIce = Q_rIce(rainVariables);
            rainVariables.Q_cal = Q_cal(rainVariables);
            //Target VALUES<-:


            rainVariables.beta = getBeta(rainVariables);
            rainVariables.m_r = getMr(rainVariables);
            rainVariables.gamma = getGamma(rainVariables);
            rainVariables.h_c = (int)getHc(rainVariables);
            //rainVariables.K; //is used if F_tot > 500 ga (not for MVP)
            //rainVariables.Z_i; //no need at all (method for z mid includes this)
            //rainVariables.Psy_i; //no need at all (method for z mid includes this)
            //rainVariables.t_c; later, not for MVP
            decimal K_y = rainVariables.K_y();
            decimal F_y = rainVariables.F_y() ;
            decimal F_roadroof = rainVariables.F_roadRoof();
            
        } //end of "method to assign input data to variables"

        double getA(RainVariables rainVariables){
             double _A = 0;

            _A = rainVariables.Q_20 * Math.Pow(20, (double)rainVariables.n)*Math.Pow((1+(Math.Log10((double)rainVariables.P)/Math.Log10((double)rainVariables.m_r))), (double)rainVariables.gamma);

            return _A;
        }

        decimal getPsy_mid(RainVariables rainvariables){
            decimal _Psy_mid = 0;

            decimal K_gravel = rainvariables.F_gravel * 0.4m; //tabl10 rek
            decimal K_road = rainvariables.F_road * 0.95m; //tabl10 rek
            decimal K_roof = rainvariables.F_roof * 0.95m; //tabl10 rek
            decimal K_green = rainvariables.F_green * 0.1m; //tabl10 rek

            _Psy_mid = (K_gravel + K_green + K_road + K_roof) / rainvariables.F;

            return _Psy_mid;
        }
        
        decimal getZ_mid(RainVariables rainvariables)
        {
            RainVariables rv = rainvariables; //for get_Z_roadAndRoof constructor parameter
            decimal _Z_mid = 0;

            decimal K_gravel = rainvariables.F_gravel * 0.125m; //tabl10 rek
            decimal K_road = rainvariables.F_road * get_Z_roadAndRoof(rv); //tabl10 rek
            decimal K_roof = rainvariables.F_roof * get_Z_roadAndRoof(rv); //tabl10 rek
            decimal K_green = rainvariables.F_green * 0.038m; //tabl10 rek

            _Z_mid = (K_gravel + K_green + K_road + K_roof)/rainvariables.F;

            return _Z_mid;
        }
            
        //getting z_road and z_roof values        

        decimal get_Z_roadAndRoof(RainVariables rainVariables) 
        {
             
            bool getN = n_LESS065(rainVariables.n);

            int A_prev = (int)Math.Floor(rainVariables.A/100)*100;
            int A_next = (int)Math.Ceiling(rainVariables.A/100)*100;

            decimal z_A_prev = 0;             //get this! by Linq.
            decimal z_A_next = 0;            //get this! by Linq.


            //getting z_road and z_roof values from db for further interpolation
            using(projectappdbContext db = new projectappdbContext()){
                if(getN==true){
                    var _z_A_prev = db.Table11ZiVodonepronitsaemie.Where(el => el.A <= A_prev).Select(el => el.NAbove065).FirstOrDefault();
                    var _z_A_next = db.Table11ZiVodonepronitsaemie.Where(el => el.A >= A_next).Select(el => el.NAbove065).FirstOrDefault();
                    z_A_prev = _z_A_prev;
                    z_A_next = _z_A_next;
                }
                else{
                    var _z_A_prev = db.Table11ZiVodonepronitsaemie.Where(el => el.A <= A_prev).Select(el => el.NLess065).FirstOrDefault();
                    var _z_A_next = db.Table11ZiVodonepronitsaemie.Where(el => el.A >= A_next).Select(el => el.NLess065).FirstOrDefault();
                    z_A_prev = _z_A_prev;
                    z_A_next = _z_A_next;
                }
                
            } //end of getting z_road and z_roof values.

            decimal deltaMain = (A_next - A_prev) / (z_A_next - z_A_prev);  //interpolation part
            decimal diff = rainVariables.A - A_prev;

            decimal InterpolationResult = z_A_prev + deltaMain * diff;

            return InterpolationResult; //end of interpolation part. end of getting z_road and z_roof values
        }

        //method for z_roadAndRoof
        bool n_LESS065(decimal _n)
        {
            if (_n < 0.65m)
                return true;
            else
                return false;
        } //end of method for z_roadAndRoof

        decimal gett_can(RainVariables rainVariables){ //lotki time
            decimal _t_can = 0;
            _t_can = 0.021m * rainVariables.l_lotok/rainVariables.v_lotok;
            return _t_can;
        }
        decimal gett_p(RainVariables rainVariables){ //collector time
            decimal _t_p = 0;
            _t_p = 0.017m * rainVariables.l_p/rainVariables.v_p;
            return _t_p;
        }

        decimal gett_r(RainVariables rainVariables){
            decimal _gett_r;
            _gett_r = gett_can(rainVariables) + gett_p(rainVariables) + rainVariables.t_con;
            return _gett_r;
        }

        decimal getN(RainVariables rainVariables){ //getting n method

            decimal _getN = 0;

            using(projectappdbContext db = new projectappdbContext()){

                string ChoosenRegion = Region.SelectionBoxItem as string;

                if (rainVariables.P >= 1){
                    var n = db.Pril2NPlessPaboveMrGamma.Where(el => el.Region == ChoosenRegion && rainVariables.P >= 1).Select(el => el.NPabove1).FirstOrDefault();
                    _getN = n;
                }
                else{
                    var n = db.Pril2NPlessPaboveMrGamma.Where(el => el.Region == ChoosenRegion && rainVariables.P < 1)
                                                       .Select(el => el.NPless1)
                                                       .FirstOrDefault(); 
                    _getN = n;               
                }
                
            }

            return _getN;
        } //end of getting n method

        decimal getBeta(RainVariables rainVariables){ //getting beta method

            decimal _beta = 0;

            decimal n = rainVariables.n; 

            if (n <= 0.4m){
                _beta = 0.8m;
            }
            else if(n <= 0.5m){
                _beta = 0.75m;
            }
            else if(n <= 0.7m){
                _beta = 0.7m;
            }
            else{
                _beta = 0.65m;
            }

            return _beta;

        }//end of getting beta method

        decimal getMr(RainVariables rainVariables){ //getting mr method

            decimal _getMr = 0;

            using(projectappdbContext db = new projectappdbContext()){
                string ChoosenRegion = Region.SelectionBoxItem as string;

                var mr = db.Pril2NPlessPaboveMrGamma.Where(el => el.Region == ChoosenRegion).Select(el => el.Mr).FirstOrDefault();
                _getMr = mr;

            }

            return _getMr;
        }//end of getting mr method

        decimal getGamma(RainVariables rainVariables){ //getting gamma method

            decimal _getGamma = 0;

            using(projectappdbContext db = new projectappdbContext()){
                string ChoosenRegion = Region.SelectionBoxItem as string;

                var mr = db.Pril2NPlessPaboveMrGamma.Where(el => el.Region == ChoosenRegion).Select(el => el.Gamma).FirstOrDefault();
                _getGamma = mr;
            }

            return _getGamma;
        } //end of getting gamma method

        decimal getHc(RainVariables rainVariables){ //getting gamma method

            decimal _Hc = 0;

            using(projectappdbContext db = new projectappdbContext()){
                int ClimateIdFromCombobox = 1;

                var Hc = db.Table12SloyTalikhVod.Where(el => el.ClimateId == ClimateIdFromCombobox ).Select(el => el.P015).FirstOrDefault();
                _Hc = Hc;
            }
            return _Hc;
        } //end of getting gamma method

        //RESULTs CALCULATION METHODs
        decimal Q_rRain(RainVariables rainVariables)
        {
            double _Q_rRain = 0;
            
            _Q_rRain = (double)rainVariables.Z_mid * (double)Math.Pow((double)rainVariables.A, 1.2) * (double)rainVariables.F / Math.Pow((double)rainVariables.t_r, 1.2 * (double)rainVariables.n - 0.1);
            val1 = (decimal)_Q_rRain;

            return val1;
        } //end of result calculation method

        decimal Q_rIce(RainVariables rainVariables)
        {
            decimal _Q_rIce = 0;
            
            _Q_rIce = (5.5m * rainVariables.h_c * rainVariables.K_y() * rainVariables.F) / (10 + rainVariables.t_r);
            val2 = _Q_rIce;

            return val2;
        } //end of result calculation method

        //Qcal calculation method
        decimal val1;
        decimal val2;
        decimal Q_cal(RainVariables rainVariables)
        {
            decimal _Q_cal = 0;

            _Q_cal = Math.Max(val1, val2) * rainVariables.beta;

            return _Q_cal;
        } // end of Qcal calculation method
    }
}
