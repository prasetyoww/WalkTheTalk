using System.ComponentModel.DataAnnotations;

namespace EpolisParam.Models
{
    public class MRESIKO
    {
        [Key]
        public int ID { get; set; }

        public string RESIKO { get; set; }

    }
}