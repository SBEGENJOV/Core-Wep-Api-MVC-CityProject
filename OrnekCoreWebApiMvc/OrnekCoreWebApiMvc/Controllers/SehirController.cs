using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrnekCoreWebApiMvc.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OrnekCoreWebApiMvc.Controllers
{
    public class SehirController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();

            var sehirler = client.GetAsync("https://localhost:44379/api/Sehir").Result;
            List<Sehir> Sehirs;
            Sehirs=JsonConvert.DeserializeObject<List<Sehir>>(sehirler.Content.ReadAsStringAsync().Result);

            var ulkeler = client.GetAsync("https://localhost:44379/api/Ulke").Result;
            List<Ulke> Ulkes;
            Ulkes = JsonConvert.DeserializeObject<List<Ulke>>(ulkeler.Content.ReadAsStringAsync().Result);


            var JoinSehir = (from s in Sehirs
                             join u in Ulkes on s.UlkeID equals u.UlkeID
                             select new ListView
                             {
                                SehirAd= s.SehirAd,
                                SehirIlceSay= s.SehirIlceSay,
                                SehirID= s.SehirID,
                                UlkeID= u.UlkeID,
                                UlkeAd= u.UlkeAd
                             }).ToList();
                //sehirs.Join(Ulkes, sehir => sehir.UlkeID, ulke => ulke.UlkeID, (sehirs, ulke) => new(Sehir = sehirs, Ulke = ulke));
            return View(JoinSehir);
        }
        public IActionResult Create ()
        {
            HttpClient client= new HttpClient();
            
            var ulkeler = client.GetAsync("https://localhost:44379/api/Ulke").Result;
            List<Ulke> Ulkes;
            Ulkes = JsonConvert.DeserializeObject<List<Ulke>>(ulkeler.Content.ReadAsStringAsync().Result);
            List<SelectListItem> data= (from s in Ulkes select new SelectListItem
            {
                Text=s.UlkeAd,
                Value=s.UlkeID.ToString()
            }).ToList();
            ViewBag.datalar = data;

            Ulkes = JsonConvert.DeserializeObject<List<Ulke>>(ulkeler.Content.ReadAsStringAsync().Result);
            return View(new Sehir());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Sehir sehir)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(sehir), System.Text.Encoding.UTF8, "application/json");
            // StringContent sınıfı, bir HTTP isteği içeriğini temsil etmek için kullanılır.
            var response = client.PostAsync("https://localhost:44379/api/Sehir", content).Result;
            // Result özelliği, yanıt alıncaya kadar geçerli iş parçacığını engeller.
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            HttpClient client= new HttpClient();
            var response = client.GetAsync($"https://localhost:44379/api/Sehir/{id}").Result;

            var ulkeler = client.GetAsync("https://localhost:44379/api/Ulke").Result;
            List<Ulke> Ulkes;
            Ulkes = JsonConvert.DeserializeObject<List<Ulke>>(ulkeler.Content.ReadAsStringAsync().Result);
            List<SelectListItem> data = (from s in Ulkes
                                         select new SelectListItem
                                         {
                                             Text = s.UlkeAd,
                                             Value = s.UlkeID.ToString()
                                         }).ToList();
            ViewBag.datalar = data;

            var sehirs=JsonConvert.DeserializeObject<Sehir>(response.Content.ReadAsStringAsync().Result);
            return View(sehirs);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Sehir sehir,int id)
        {
            HttpClient client= new HttpClient();
            StringContent strcont= new StringContent(JsonConvert.SerializeObject(sehir), System.Text.Encoding.UTF8,"application/json");
            var response = client.PutAsync($"https://localhost:44379/api/Sehir/{id}", strcont).Result;
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            HttpClient client= new HttpClient();
            var response = client.DeleteAsync($"https://localhost:44379/api/Sehir/{id}").Result;
            return RedirectToAction("Index");

        }
    }
}
