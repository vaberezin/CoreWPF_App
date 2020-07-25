using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreWpfApp.AppDB;

namespace CoreWpfApp
{
    static class ListForCombobox
    {
        
        

        static internal List<string> getRegionList()
        {
            List<string> RegionList;
            using (projectappdbContext db = new projectappdbContext())
            {
                var Regions = db.Pril2NPlessPaboveMrGamma.Select(p => p.Region).ToList();
                RegionList = Regions;
            }
            return RegionList;
        }

        static internal List<string> getPlaceList()
        {
            List<string> PlaceList;
            using (projectappdbContext db = new projectappdbContext())
            {
                var Places = db.Pril11RegionIdHcpCvCs.Select(r => r.RegionName).ToList();

                PlaceList = Places;
            }
            return PlaceList;
        }

        


    }
}
