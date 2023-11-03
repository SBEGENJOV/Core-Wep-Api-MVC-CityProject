using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrnekCoreWebApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OrnekCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SehirController : ControllerBase
    {
        public readonly ApplicationDbContext Context;
        public SehirController(ApplicationDbContext context)
        {
            this.Context = context;
        }
        public IActionResult Index()
        {
            return Ok(Context.Sehirs.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult IndexByID(int id)
        {
           // return Ok(Context.Sehirs.FirstOrDefault(m=>m.SehirID==id));
            return Ok(Context.Sehirs.Find(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddSehir(Sehir sehir)
        {
            Context.Sehirs.Add(sehir);
            await Context.SaveChangesAsync();
            return Created("", sehir);
        }
        [HttpPut("{id}")]
        public IActionResult EditSehir (Sehir sehir)
        {
            Context.Sehirs.Update(sehir);
            Context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSehir(int id)
        {
            var result = Context.Sehirs.FirstOrDefault(m => m.SehirID == id);
            Context.Remove(result);
            Context.SaveChanges();
            return NoContent();
        }
    }
}
