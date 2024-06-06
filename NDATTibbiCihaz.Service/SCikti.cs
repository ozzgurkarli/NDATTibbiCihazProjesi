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

        public Cikti EkleCiktiGorsellerIle(Cikti Cikti, string Path3D, string Name3D, List<string> FilePaths, List<string> FileNames)
        {
            Cikti.Path3D = $"/3DFiles/{DateTime.Now.ToFileTime()}_{Cikti.HastaTCKimlikNo}_{Name3D}";
            File.Copy(Path3D, Cikti.Path3D);

            Cikti item = eCikti.EkleCikti(Cikti);

            List<Gorsel> gorselList = new List<Gorsel>();

            for(int i=0; i< FilePaths.Count; i++)
            {
                long time = DateTime.Now.ToFileTime();
                string path = $"/Images/{time}_{Cikti.HastaTCKimlikNo}_{i}_{FileNames[i]}";
                string pathFile = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @$"..\..\..\Images\{time}_{Cikti.HastaTCKimlikNo}_{i}_{FileNames[i]}"));
                File.Copy(FilePaths[i], pathFile);
                gorselList.Add(new Gorsel { Aci = i * (Cikti.DonulenDerece / FilePaths.Count), CiktiId = Cikti.Id, PathGorsel = path });
            }

            item.Gorseller = gorselList;

            return eCikti.GuncelleCiktiGorseller(item);
        }

        public Cikti EkleRaporIdCikti(Cikti cikti)
        {
            return eCikti.GuncelleCiktiRapor(cikti);
        }
    }
}
