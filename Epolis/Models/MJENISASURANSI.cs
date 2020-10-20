using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPolis.Models
{
    public class MJENISASURANSI
    {
        public int ID { get; set; }

        [Display(Name = "Kode Jenis Asuransi")]
        [Required(ErrorMessage = "Kode Jenis Asuransi harus diisi")]
        public string KODEJENISASURANSI { get; set; }

        [Display(Name = "Jenis Asuransi")]
        [StringLength(100, MinimumLength = 1)]
        [Required(ErrorMessage = "Jenis Asuransi harus diisi")]
        public string JENISASURANSI { get; set; }
        public string UPDATEDBY { get; set; }
        public DateTime? UPDATEDDATE { get; set; }
    }
}
