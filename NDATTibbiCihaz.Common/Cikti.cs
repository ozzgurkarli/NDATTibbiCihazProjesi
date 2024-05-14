using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDATTibbiCihaz.Common
{
    public class Cikti
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public long HastaTCKimlikNo { get; set; }

        public List<Gorsel> Gorseller { get; set; }

        public int RaporId { get; set; }

        public string Path3D { get; set; }

        public DateTime CiktiTarihi { get; set; }

        public decimal DonulenDerece { get; set; }
    }
}
