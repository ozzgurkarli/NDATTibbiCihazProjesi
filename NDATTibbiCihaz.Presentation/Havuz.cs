﻿using NDATTibbiCihaz.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDATTibbiCihaz.Presentation
{
    internal static class Havuz
    {
        public static Doktor Doktor { get; set; }
        public static Hasta Hasta { get; set; }

        public static List<Cikti> Ciktilar { get; set; }
    }
}
