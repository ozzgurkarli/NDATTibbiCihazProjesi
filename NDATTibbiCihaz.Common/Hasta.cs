using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDATTibbiCihaz.Common
{
    public class Hasta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long TCKimlikNo { get; set; }

        public string AdSoyad { get; set; }

        public bool Cinsiyet { get; set; }

        public DateTime DogumTarihi { get; set; }

        public List<Cikti> Ciktilar { get; set; }

        public bool MedeniDurum { get; set; }

        public int DoktorId { get; set; }
    }
}
