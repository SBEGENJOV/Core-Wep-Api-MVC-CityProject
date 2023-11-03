using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OrnekCoreWebApiMvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrnekCoreWebApiMvc.Controllers
{
    public class IlceController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var repos = client.GetAsync("https://localhost:44379/api/Koy").Result;
            List<Ilce> Ilces;
            Ilces=JsonConvert.DeserializeObject<List<Ilce>>(repos.Content.ReadAsStringAsync().Result);


            var sehir = client.GetAsync("https://localhost:44379/api/Sehir").Result;
            List<Sehir> Sehirler;
            Sehirler = JsonConvert.DeserializeObject<List<Sehir>>(sehir.Content.ReadAsStringAsync().Result);


            var list=(from i in Ilces join s in Sehirler on i.SehirID equals s.SehirID select new ListView
            {
                IlceID = i.IlceID,
                IlceAd=i.IlceAd,
                IlceBaskan=i.IlceBaskan,
                SehirID=s.SehirID,
                SehirAd=s.SehirAd
            }).ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            HttpClient client= new HttpClient();
            var sehir = client.GetAsync("https://localhost:44379/api/Sehir").Result;
            List<Sehir> Sehirler;
            Sehirler = JsonConvert.DeserializeObject<List<Sehir>>(sehir.Content.ReadAsStringAsync().Result);
            List<SelectListItem> data = (from s in Sehirler
                                         select new SelectListItem
                                         {
                                             Text = s.SehirAd,
                                             Value = s.SehirID.ToString()
                                         }).ToList();
            ViewBag.datalar = data;

            return View(new Ilce());
        }
        [HttpPost]
        public IActionResult Create(Ilce ilce) 
        {
            HttpClient client = new HttpClient();
            StringContent repos =new StringContent(JsonConvert.SerializeObject(ilce), System.Text.Encoding.UTF8, "application/json");
            _=client.PostAsync("https://localhost:44379/api/Koy", repos).Result;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit (int id)
        {
            HttpClient client=new HttpClient();
            var repos = client.GetAsync($"https://localhost:44379/api/Koy/{id}").Result;
            
            var Ilce = JsonConvert.DeserializeObject<Ilce>(repos.Content.ReadAsStringAsync().Result);

            var sehir = client.GetAsync("https://localhost:44379/api/Sehir").Result;
            List<Sehir> Sehirler;
            Sehirler = JsonConvert.DeserializeObject<List<Sehir>>(sehir.Content.ReadAsStringAsync().Result);
            List<SelectListItem> data = (from s in Sehirler
                                         select new SelectListItem
                                         {
                                             Text = s.SehirAd,
                                             Value = s.SehirID.ToString()
                                         }).ToList();
            ViewBag.datalar = data;
            return View(Ilce);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Ilce ilce, int id)
        {
            HttpClient client = new HttpClient();
            StringContent strcont = new StringContent(JsonConvert.SerializeObject(ilce), System.Text.Encoding.UTF8, "application/json");
            var response = client.PutAsync($"https://localhost:44379/api/Koy/{id}", strcont).Result;
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>Delete(int id)
        {
            HttpClient client=new HttpClient();
            var respos = client.DeleteAsync($"https://localhost:44379/api/Koy/{id}").Result;
            return RedirectToAction("Index");
        }
    }
}
