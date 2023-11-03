namespace OrnekCoreWebApiMvc.Models
{
    public class ListView
    {
        public int IlceID { get; set; }
        public string IlceAd { get; set; }
        public int IlceBaskan { get; set; }
        public int SehirID { get; set; }
        public string SehirAd { get; set; }
        public int SehirIlceSay { get; set; }
        public int UlkeID { get; set; }
        public string UlkeAd { get; set; }
        public int UlkeSehirSay { get; set; }
        public string UlkeBaskent { get; set; }
    }
}
