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

        public Cikti EkleCikti(Cikti Cikti)
        {
            db.Ciktilar.Add(Cikti);

            db.SaveChanges();

            return db.Ciktilar.Where(x => x.Path3D.Equals(Cikti.Path3D) && x.HastaTCKimlikNo.Equals(Cikti.HastaTCKimlikNo)).First();
        }
        public Cikti GuncelleCikti(Cikti Cikti)
        {
            Cikti item = db.Ciktilar.Where(x => x.Id.Equals(Cikti.Id)).First();

            item.Gorseller = Cikti.Gorseller;

            db.SaveChanges();

            return item;
        }
    }
}
