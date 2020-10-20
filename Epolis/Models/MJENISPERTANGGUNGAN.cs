using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPolis.Models
{
    public class MJENISPERTANGGUNGAN
    {
        public int ID { get; set; }
        [Display(Name = "Kode Okupasi")]
        public int OKUPASIID { get; set; }

        //public int KODEOKUPASI { get; set; }

        [Display(Name = "Kode Pertanggungan")]
        public string KODEPERTANGGUNGAN { get; set; }

        [Display(Name = "Deskripsi")]
        public string DESKRIPSI { get; set; }

        [Display(Name = "Rate Pertanggungan")]
        public Decimal RATEPERTANGGUNGAN { get; set; }

        [Display(Name = "Resiko")]
        public int RESIKOID { get; set; }

        [Display(Name = "Updated By")]
        public string UPDATEDBY { get; set; }

        [Display(Name = "Update Date")]
        public DateTime UPDATEDATE { get; set; }
    }
}
