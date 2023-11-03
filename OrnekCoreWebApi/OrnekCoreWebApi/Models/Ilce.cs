using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrnekCoreWebApi.Models
{
    public class Ilce
    {
        [Key]
        public int IlceID { get; set; }
        public string IlceAd { get; set; }
        public int IlceBaskan { get; set; }
        public int SehirID { get; set; }
        [ForeignKey("SehirID")]
        public Sehir Sehir { get; set; }
    }
}
