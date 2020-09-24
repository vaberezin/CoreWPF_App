using System;
using System.Collections.Generic;
using System.Text;
using CoreWpfApp.AppDB;
using System.Linq;

namespace CoreWpfApp
{
    public class RegulationsModel
    {
        public IEnumerable<Regulation> _getRegulations;
        //public IEnumerable<Regulations> Load()
        //{
            
            
        //}

        public RegulationsModel()
        {
            using (projectappdbContext db = new projectappdbContext())
            {
                _getRegulations = db.Regulations.Where(reg => reg.Id >=25).ToList();
            }
        }
    }
}
