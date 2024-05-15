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
    public class EDoktor()
    {
        private readonly CihazDbContext db = new CihazDbContext();

        public Doktor? OkuDoktor(Doktor item)
        {
            Doktor? doktor = db.Doktorlar.Where(x => x.Id == item.Id).FirstOrDefault();

            return doktor;
        }
    }
}
