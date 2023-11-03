using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrnekCoreWebApiMvc.Models
{
    public class Sehir
    {
        [Key]
        public int SehirID { get; set; }
        public string SehirAd { get; set; }
        public int SehirIlceSay { get; set; }
        public int UlkeID { get; set; }
        [ForeignKey("UlkeID")]
        public Ulke Ulke { get; set; }
    }
}
