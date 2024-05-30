using NDATTibbiCihaz.Common;
using NDATTibbiCihaz.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDATTibbiCihaz.Service
{
    public class SHasta()
    {
        private readonly EHasta eHasta = new EHasta();

        public List<Hasta> AramaHasta(Hasta item)
        {
            List<Hasta> hastaList = new List<Hasta>();
            long tckNo = 0;

            if (long.TryParse(item.AdSoyad, out tckNo))
            {
                item.TCKimlikNo = tckNo;
                Hasta? hasta = eHasta.OkuHastaTCKNoIle(item);

                if(hasta != null)
                {
                    hastaList.Add(hasta);
                }
            }
            else
            {
                hastaList = eHasta.GetirHastaAdSoyadIle(item);
            }

            return hastaList;
        }
    }
}
