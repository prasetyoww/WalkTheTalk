using EpolisParam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPolis.Models
{
    public class ViewModel
    {
        public MOKUPASI okupasi { get; set; }
        public MRESIKO resiko { get; set; }
        public MJENISPERTANGGUNGAN pertanggungan { get; set; }
    }
}
