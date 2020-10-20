using EPolis.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpolisParam.Models
{
    public class Mpertanggungan
    {
        public int ID { get; set; }

        public MOKUPASI MOKUPASI { get; set; }

        [Display(Name = "Kode Pertanggungan")]
        [StringLength(10, MinimumLength = 1)]
        public string KODEPERTANGGUNGAN { get; set; }
        [Display(Name = "Deskripsi")]
        [StringLength(10, MinimumLength = 1)]
        public string DESKRIPSI { get; set; }
        [Display(Name = "Rate")]
        [Column(TypeName = "decimal(10,4)")]
        public decimal RATEPERTANGGUNGAN { get; set; }
        [Display(Name = "Resiko")]
        [StringLength(15, MinimumLength = 1)]
        public string RESIKO { get; set; }

        [StringLength(50, MinimumLength = 0)]
        public string UPDATEDBY { get; set; }
        [DataType(DataType.Date)]
        public DateTime UPDATEDATE { get; set; }
    }
}
