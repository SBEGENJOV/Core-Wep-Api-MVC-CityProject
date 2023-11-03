using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrnekCoreWebApi.Models;
using System.Linq;

namespace OrnekCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UlkeController : ControllerBase
    {
        public readonly ApplicationDbContext Context;
        public UlkeController(ApplicationDbContext context)
        {
            this.Context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(Context.Ulkes.ToList());
        }
        [HttpGet("{id}")] //api/sporcular//ıd
        public IActionResult IndexSprId(int id)
        {
            //return Ok(Context.Ulkes.Find(id);
            return Ok(Context.Ulkes.FirstOrDefault(m => m.UlkeID == id));
        }
        [HttpPost]
        public IActionResult AddUlke(Ulke ulke)
        {
            Context.Add(ulke);
            Context.SaveChanges();
            return Created("", ulke);
        }
        [HttpPut("{id}")]//api/sporcular/1
        public IActionResult UpdateUlke(int id, Ulke ulke)
        {
            var result = Context.Ulkes.FirstOrDefault(m => m.UlkeID == id);
            result.UlkeAd = ulke.UlkeAd;
            result.UlkeBaskent = ulke.UlkeBaskent;
            result.UlkeSehirSay = ulke.UlkeSehirSay;
            //Context.Update(ulke);
            Context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUlke(int id)
        {
            var result = Context.Ulkes.FirstOrDefault(m => m.UlkeID == id);
            Context.Remove(result);
            Context.SaveChanges();
            return NoContent();
        }
    }
}
