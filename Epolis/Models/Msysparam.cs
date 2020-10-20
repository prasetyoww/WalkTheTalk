using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epolis.Models
{
    public class Msysparam
    {
        public int ID { get; set; }

        [StringLength(20, MinimumLength = 0)]
        public string PARAMCODE { get; set; }
        [StringLength(50, MinimumLength = 0)]
        public string PARAMNAME { get; set; }
        [StringLength(100, MinimumLength = 0)]
        public string PARAMVALUE { get; set; }
        [StringLength(100, MinimumLength = 0)]
        public string PARAMDESC { get; set; }
        [StringLength(1, MinimumLength = 1)]
        public string ISMASKED { get; set; }
        [StringLength(50, MinimumLength = 0)]
        public string PARAMGROUP { get; set; }

        public int ORDERNO { get; set; }

        [StringLength(50, MinimumLength = 0)]
        public string UPDATEDBY { get; set; }
        [DataType(DataType.Date)]
        public DateTime UPDATEDATE { get; set; }
    }
}
