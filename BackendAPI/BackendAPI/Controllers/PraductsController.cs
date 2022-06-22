using BackendAPI.DAL;
using BackendAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PraductsController : ControllerBase
    {
        private readonly AppLicotionDbContext context;

        public PraductsController(AppLicotionDbContext context)
        {
            this.context = context;
        }
        //private List<Praduct> praducts = new List<Praduct>()
        //{
        //    new Praduct
        //    {
        //        Id = 1,
        //        Name = "phone",
        //        Price = 150.5m
        //    },
        //    new Praduct
        //    {
        //        Id = 2,
        //        Name = "TV",
        //        Price = 150.5m
        //    },
        //    new Praduct
        //    {
        //        Id = 3,
        //        Name = "Notebook",
        //        Price = 150.5m
        //    },
        //    new Praduct
        //    {
        //        Id = 4,
        //        Name = "",
        //        Price = 150.5m
        //    }
        //};

        [HttpGet("get{id}")]
        public IActionResult Get(int id)
        {
            Praduct praduct = context.praducts.FirstOrDefault(b => b.Id == id);
            if (praduct == null) return NotFound();
            return Ok(praduct);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            List<Praduct> praducts = await context.praducts.ToListAsync();
            return Ok(praducts);
        }
        [HttpPost("create")]
        public IActionResult Create(Praduct praduct)
        {
            if (praduct.Name.Length > 5) return StatusCode(StatusCodes.Status400BadRequest, new { title = "you have to set name length max 6 charcters" });
                context.praducts.Add(praduct);
            context.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Update(Praduct praduct, int id)
        {
            Praduct exsist = context.praducts.FirstOrDefault(b => b.Id == id);
            if (exsist == null) return NotFound();

            //exsist.Name = praduct.Name;
            //exsist.Price = praduct.Price;
            context.Entry(exsist).CurrentValues.SetValues(praduct);
            context.SaveChanges();
            return Ok(praduct);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            Praduct exsist = context.praducts.Find(id);
            if (exsist == null) return NotFound();
            context.praducts.Remove(exsist);
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { id });
        }
    }
}
