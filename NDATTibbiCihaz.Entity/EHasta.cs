using Microsoft.EntityFrameworkCore;
using NDATTibbiCihaz.Common;
using NDATTibbiCihaz.Entity.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDATTibbiCihaz.Entity
{
    public class EHasta()
    {
        private readonly CihazDbContext db = new CihazDbContext();

        public Hasta? OkuHastaTCKNoIle(Hasta item)
        {
            return db.Hastalar.Where(x => x.TCKimlikNo == item.TCKimlikNo).FirstOrDefault();
        }

        public List<Hasta> GetirHastaAdSoyadIle(Hasta item)
        {
            return db.Hastalar.Where(x => x.AdSoyad.ToLower().Contains(item.AdSoyad.ToLower())).ToList();
        }
    }
}
