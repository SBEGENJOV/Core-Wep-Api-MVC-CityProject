using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrnekCoreWebApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OrnekCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KoyController : ControllerBase
    {
        public readonly ApplicationDbContext Context;
        public KoyController(ApplicationDbContext context)
        {
            this.Context = context;
        }
        [HttpGet]
        public IActionResult KoyIndex()
        {
            return Ok(Context.Ilces.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult IndexByID(int id)
        {
            // return Ok(Context.Sehirs.FirstOrDefault(m=>m.SehirID==id));
            return Ok(Context.Ilces.Find(id));
        }
        [HttpPost]
        public IActionResult KoyAdd(Ilce ilce)
        {
            Context.Add(ilce);
            Context.SaveChangesAsync();
            return Created("", ilce);
        }
        [HttpPut("{IlceID}")]
        public IActionResult KoyEdit(Ilce ilce)
        {
            Context.Ilces.Update(ilce);
            Context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult KoyDelete(int id)
        {
            Context.Remove(Context.Ilces.Find(id));
            Context.SaveChangesAsync();
            return NoContent();
            //akefosk
        }
    }
}
