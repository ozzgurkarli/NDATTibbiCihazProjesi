using Microsoft.IdentityModel.Tokens;
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

        public Hasta OkuHasta(Hasta item)
        {
            Hasta? hasta = null;
            long tckNo = 0;

                if (item.TCKimlikNo>= 100000000000 && item.TCKimlikNo < 10000000000)
                {
                    throw new Exception(message: "TCK No hatalı girildi.");
                }

                hasta = eHasta.OkuHastaTCKNoIle(item);

                if (hasta == null)
                {
                    throw new Exception(message: "Hasta bulunamadı.");
                }

            return hasta;
        }

        public List<Hasta> AramaHasta(Hasta item)
        {
            List<Hasta> hastaList = new List<Hasta>();
            long tckNo = 0;

            if (long.TryParse(item.AdSoyad, out tckNo))
            {
                if(item.AdSoyad.Length != 11)
                {
                    throw new Exception(message: "TCK No hatalı girildi.");
                }
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

            if (hastaList.IsNullOrEmpty())
            {
                throw new Exception(message: "Hasta bulunamadı.");
            }

            return hastaList;
        }
    }
}
