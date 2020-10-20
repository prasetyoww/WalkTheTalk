using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.Models
{
    public class Mmenu
    {
        public int ID { get; set; }
        public string MenuText { get; set; }
        public string ParentId { get; set; }

        public List<Mmenu> List { get; set; }
    }
}
