using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrnekCoreWebApiMvc.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace OrnekCoreWebApiMvc.Controllers
{
    public class UlkeController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://localhost:44379/api/Ulke").Result;
            List<Ulke> Ulkes;

            Ulkes = JsonConvert.DeserializeObject<List<Ulke>>(response.Content.ReadAsStringAsync().Result);
            return View(Ulkes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Ulke());
        }
        [HttpPost]
        public IActionResult Create(Ulke Ulke)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(Ulke), System.Text.Encoding.UTF8, "application/json");//create sayfasına girdigimiz verileri json formatına dönüştürdü.

            var respone = client.PostAsync("https://localhost:44379/api/Ulke", content).Result;//url içeriside post işlemlerini gerçekleştirdi content ile aslında json formatın adönüşmüş verilerim gitmiş oldu.

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://localhost:44379/api/Ulke/{id}").Result;

            var Ulkes = JsonConvert.DeserializeObject<Ulke>(response.Content.ReadAsStringAsync().Result);
            return View(Ulkes);
        }

        [HttpPost]
        public IActionResult Edit(Ulke Ulke)
        {
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(Ulke), System.Text.Encoding.UTF8, "application/json");

            var respone = client.PutAsync($"https://localhost:44379/api/Ulke/{Ulke.UlkeID}", content).Result;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.DeleteAsync($"https://localhost:44379/api/Ulke/{id}").Result;

            return RedirectToAction("Index");
        }
    }
}
