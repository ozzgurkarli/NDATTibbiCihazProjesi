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
    public class ECikti()
    {
        private readonly CihazDbContext db = new CihazDbContext();

        public List<Cikti> GetirCikti(Cikti item)
        {
            return db.Ciktilar.Where(x => x.HastaTCKimlikNo == item.HastaTCKimlikNo).Include(x => x.Gorseller).ToList();
        }
    }
}
