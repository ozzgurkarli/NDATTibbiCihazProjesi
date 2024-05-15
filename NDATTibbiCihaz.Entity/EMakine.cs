using NDATTibbiCihaz.Common;
using NDATTibbiCihaz.Entity.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDATTibbiCihaz.Entity
{
    public class EMakine
    {
        private readonly CihazDbContext db = new CihazDbContext();

        public Makine? OkuMakine(Makine makine)
        {
            return db.Makineler.Where(x => x.Id == makine.Id).FirstOrDefault();
        }

        public List<Makine> GetirMakine()
        {
            List<Makine> makineler = db.Makineler.ToList();

            return makineler;
        }
    }
}
