using System;
using System.Collections.Generic;
using System.Text;
using CoreWpfApp.AppDB;
using System.Linq;
using System.Collections.ObjectModel;

namespace CoreWpfApp
{
    public class RegulationsModel
    {
        public ObservableCollection<Regulation> _getRegulations;
        //public IEnumerable<Regulations> Load()
        //{
            
            
        //}

        public RegulationsModel()
        {
            using (projectappdbContext db = new projectappdbContext())
            {
                var GiveMeDataGridRows = db.Regulations.Where(reg => reg.Id >=25);
                _getRegulations = new ObservableCollection<Regulation>(GiveMeDataGridRows);
            }
        }
    }
}
