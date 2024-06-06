using NDATTibbiCihaz.Common;
using NDATTibbiCihaz.Entity.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDATTibbiCihaz.Entity
{
    public class ERapor
    {
        private readonly CihazDbContext db = new CihazDbContext();

        public Rapor? OkuRapor(Rapor item)
        {
            return db.Raporlar.Where(x => x.Id == item.Id).FirstOrDefault();
        }

        public Rapor EkleRapor(Rapor item)
        {
            Rapor rapor = db.Raporlar.Add(item).Entity;

            db.SaveChanges();

            return item;
        }
    }
}
