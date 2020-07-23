using System;
using System.Collections.Generic;
using System.Text;

namespace CoreWpfApp.RainCalcs
{
    public class RainVariables
    {
        //Variables initialization

        internal decimal F; //ok+
        internal decimal F_road; //ok+
        internal decimal F_green;  //ok+
        internal decimal F_roof; //ok+
        internal decimal F_gravel; //ok+
        internal decimal n; //Pril2 table +
        internal decimal A;  //method+
        internal decimal Psy_mid; //method+
        internal decimal Z_mid; //method+
        public int N_sections;
        internal decimal t_r;
        internal decimal t_con; //ok+
        internal decimal t_can; //method+
        internal decimal t_p; //method+
        internal decimal l_lotok; //ok+
        internal decimal v_lotok; //ok+
        internal decimal l_p; //ok+
        internal decimal v_p; //ok+
        internal decimal Q_rRain; //method+
        internal decimal Q_rIce; //method+
        internal decimal beta; //table+
        internal decimal Q_cal; //method+
        internal int Q_20; //table+
        internal decimal P; //table+
        internal decimal m_r; //table
        internal decimal gamma; //table
        internal decimal K; //table
        internal decimal Z_i; //table
        internal decimal Psy_i; //table
        internal int h_c; //table
        public decimal t_c() //
        {
             return t_p;
        }
        public decimal K_y() // -> METHOD 21072020+
        
        {
            decimal _F_y = F_y();
            return 1 - (_F_y / F);
        }
        public decimal F_y() // -> METHOD 21072020+
        
        {
            return F_road;
        }

        public decimal F_roadRoof() //-> METHOD 21072020+
        
        {
            return F_road + F_roof;
            
        }

        

        
    }
}
