using NDATTibbiCihaz.Common;
using NDATTibbiCihaz.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDATTibbiCihaz.Service
{
    public class SDoktor()
    {
        private readonly EDoktor eDoktor = new EDoktor();

        public Doktor OkuDoktor(Doktor item)
        {
            if (item.Id == 0)
            {
                throw new Exception(message: "ID boş olamaz.");
            }
            else if (string.IsNullOrWhiteSpace(item.Parola))
            {
                throw new Exception(message: "Parola boş olamaz.");
            }

            Doktor? doktor = eDoktor.OkuDoktor(item);

            if (doktor == null)
            {
                throw new Exception(message: "Doktor bulunamadı.");
            }
            else if (item.Parola != doktor.Parola)
            {
                throw new Exception(message: "Parola hatalı.");
            }

            return doktor;
        }
    }
}
