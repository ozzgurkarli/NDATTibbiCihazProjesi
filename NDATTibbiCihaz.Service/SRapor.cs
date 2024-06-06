using NDATTibbiCihaz.Common;
using NDATTibbiCihaz.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDATTibbiCihaz.Service
{
    public class SRapor
    {
        private readonly ERapor eRapor = new ERapor();
        private readonly SCikti sCikti = new SCikti();

        public Rapor OkuRaporIdIle(Rapor rapor)
        {
            if(rapor.Id == 0)
            {
                throw new Exception(message: "Çıktıya ait rapor bulunamadı.");
            }

            Rapor? item = eRapor.OkuRapor(rapor);

            return item ?? throw new Exception(message: "Çıktıya ait rapor bulunamadı.");
        }

        public Rapor EkleRapor(Rapor Rapor, Cikti cikti)
        {
            Rapor rapor = eRapor.EkleRapor(Rapor);

            cikti.RaporId = rapor.Id;
            sCikti.EkleRaporIdCikti(cikti);

            return rapor;
        }
    }
}
