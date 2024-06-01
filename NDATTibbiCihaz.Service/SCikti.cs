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
    public class SCikti
    {
        private readonly ECikti eCikti = new ECikti();

        public List<Cikti> GetirCiktilarTCKIle(Cikti item)
        {
            List<Cikti> ciktiList = eCikti.GetirCikti(item);

            return ciktiList.OrderByDescending(x => x.CiktiTarihi).ToList();
        }
    }
}
