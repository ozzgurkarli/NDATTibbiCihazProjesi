using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDATTibbiCihaz.Common
{
    public class Makine
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public bool KapakDurumu { get; set; }

        public bool XRayDurumu { get; set; }

        public bool PlatformDonusDurumu { get; set; }

        public bool TaramaDurumu { get; set; }

        public bool Kullanilabilirlik { get; set; }

        public bool Calisiyor { get; set; }
    }
}
