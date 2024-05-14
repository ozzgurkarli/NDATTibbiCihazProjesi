using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDATTibbiCihaz.Common
{
    public class Rapor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int DoktorId { get; set; }

        public int CiktiId { get; set; }

        public DateTime RaporTarihi { get; set; }

        public string Yorum { get; set; }
    }
}
