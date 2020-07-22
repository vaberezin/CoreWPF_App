using System;
using System.Collections.Generic;
using System.Text;

namespace CoreWpfApp.RainCalcs
{
    public class RainVariables
    {
        //Variables initialization

        internal double F; //ok+
        internal double F_road; //ok+
        internal double F_green;  //ok+
        internal double F_roof; //ok+
        internal double F_gravel; //ok+
        internal double n; //Pril2 table +
        internal double A;  //method+
        internal double Psy_mid; //method+
        internal double Z_mid; //method+
        public int N_sections;
        internal double t_con; //ok+
        internal double t_can; //method+
        internal double t_p; //method+
        internal double l_lotok; //ok+
        internal double v_lotok; //ok+
        internal double l_p; //ok+
        internal double v_p; //ok+
        internal double Q_rRain; //method+
        internal double Q_rIce; //method+
        internal double beta; //table+
        internal double Q_cal; //method+
        internal int Q_20; //table+
        internal double P; //table+
        internal double m_r; //table
        internal double gamma; //table
        internal double K; //table
        internal double Z_i; //table
        internal double Psy_i; //table
        internal int h_c; //table
        public double t_c() //
        {
             return t_p;
        }
        public double K_y() // -> METHOD 21072020+
        
        {
            double _F_y = F_y();
            return 1 - (_F_y / F);
        }
        public double F_y() // -> METHOD 21072020+
        
        {
            return F_road;
        }

        public double F_roadRoof() //-> METHOD 21072020+
        
        {
            return F_road + F_roof;
            
        }

        public double t_r() //-> METHOD 21072020+
        {
             return t_con + t_can + t_p;
        }

        
    }
}
