using System.ComponentModel.DataAnnotations;

namespace OrnekCoreWebApiMvc.Models
{
    public class Ulke
    {
        [Key]
        public int UlkeID { get; set; }
        public string UlkeAd { get; set; }
        public int UlkeSehirSay { get; set; }
        public string UlkeBaskent { get; set; }
    }
}
