using EpolisParam.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPolis.Models
{
    public class MOKUPASI
    {
        public int ID { get; set; }

        [Display(Name = "Kode Okupasi")]
        public string KODEOKUPASI { get; set; }

        [Display(Name = "Nama Okupasi")]
        public string NAMAOKUPASI { get; set; }

        [Display(Name = "Rate Standar")]
        //[DataType(DataType.Custom)]
        //[DisplayFormat(DataFormatString = "{0:0.##}")]
        [Column(TypeName = "decimal(18, 2)")]
        public Decimal RATESTANDAR { get; set; }

        [Display(Name = "Standar Kelas 1")]
        [Column(TypeName = "decimal(18, 2)")]
        //[DataType(DataType.Custom)]
        public Decimal STDKELAS1 { get; set; }
        
        [Display(Name = "Standar Kelas 2")]
        [Column(TypeName = "decimal(18, 2)")]
        //[DataType(DataType.Custom)]
        public Decimal STDKELAS2 { get; set; }

        [Display(Name = "Resiko")]
        public int? RESIKOID { get; set; }
        public MRESIKO RESIKO { get; set; }

        [Display(Name = "Updated By")]
        public string UPDATEDBY { get; set; }

        [Display(Name = "Update Date")]
        public DateTime? UPDATEDATE { get; set; }

        //public int? UPDATEDBYID { get; set; }
        //public DateTime? UPDATEDTIME { get; set; }
        //public bool? ISDELETED { get; set; }
        //public int? DELETEDBYID { get; set; }
        //public DateTime? DELETEDTIME { get; set; }
        //public DateTime? CREATEDTIME { get; set; }
        //public int? CREATEDBYID { get; set; }

    }
}
