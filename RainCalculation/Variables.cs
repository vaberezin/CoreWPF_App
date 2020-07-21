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

class RainVariables
{
        //Variables initialization
        
        internal double F; //ok
        internal double F_road; //ok
        internal double F_green;  //ok
        internal double F_roof; //ok
        internal double F_gravel; //ok
        internal double n; //Pril2 table
        internal double A;  //method
        internal double Psy_mid; //method
        internal double Z_mid; //method
         public double t_r //property+
         {
             get { return t_con + t_can + t_p; }            
         } 
        internal double t_con; //enum
        internal double t_can; //method
        internal double t_p; //method
        internal double l_can; //ok
        internal double v_can; //ok
        internal double l_p; //ok
        internal double v_p; //ok
        internal double Q_rRain; //method
        internal double Q_rIce; //method
        internal double beta; //table
        internal double Q_cal; //method
        internal int Q_20; //table
        internal double P; //table
        internal double m_r; //table
        internal double gamma; //table
        internal double K; //table
        internal double Z_i; //table
        internal double Psy_i; //table
        internal int h_c; //table
        public double t_c //property+
        {
            get { return t_p; }
        }
        public double K_y //property+
        {
            get { return 1-(F_y/F); }
        }
        double F_y //property+
        {
            get { return F_road; }
        }

        public double F_roadRoof //property+
        {
            get { return F_road + F_roof; }
            set { F_roadRoof = value; }
        }

        
    }
}
