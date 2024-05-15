using NDATTibbiCihaz.Common;
using NDATTibbiCihaz.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDATTibbiCihaz.Service
{
    public class SMakine
    {
        private readonly EMakine eMakine = new EMakine();

        public Makine OkuMakine(Makine makine)
        {
            Makine? item = eMakine.OkuMakine(makine);

            if(item == null)
            {
                throw new Exception(message: "Bilinmeyen hata.");
            }

            return item;
        }

        public List<int> GetirMakineIdleri()
        {
            List<Makine> makineler = eMakine.GetirMakine();

            return makineler.Where(x=> x.Kullanilabilirlik == true).Select(x => x.Id).ToList();
        }
    }
}
