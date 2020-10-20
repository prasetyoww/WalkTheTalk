using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPolis.Models
{
    public class MPERLUASAN
    {
        public int ID { get; set; }

        [Display(Name = "Kode Okupasi")]
        public MOKUPASI OKUPASI { get; set; }

        [Display(Name = "Kode Perluasan")]
        public string KODEPERLUASAN{ get; set; }

        [Display(Name = "Deskripsi")]
        public string DESKRIPSI { get; set; }

        [Display(Name = "Rate Perluasan")]
        public Decimal RATEPERLUASAN { get; set; }

        [Display(Name = "Resiko")]
        public string RESIKO { get; set; }

        [Display(Name = "Update By")]
        public string UPDATEDBY { get; set; }

        [Display(Name = "Upload Date")]
        public DateTime UPLOADDATE { get; set; }

    }
}
