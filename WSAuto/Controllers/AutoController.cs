using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WSAuto.Contexto;
using WSAuto.Models;

namespace WSAuto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        public AutoDbContext Context { get; set; }

        public AutoController(AutoDbContext context)
        {
            this.Context = context;
        }

        [HttpGet]

        public IEnumerable Get()
        {
            List<Auto> autos = Context.Autos.ToList();
            return autos;

        }

        //[HttpGet("{id}")]//traer un auto por id

        //public Auto Get(int id)
        //{
        //    Auto unAuto = Context.Autos.Find(id);
        //    return unAuto;
        //}

        [HttpGet("{id}", Name = "ObtenerAuto")]
        public ActionResult<Auto> Get(int id)
        {
            var resultado = Context.Autos.FirstOrDefault(x => x.Id == id);
            if (resultado == null)
            { return NotFound(); }
            return resultado;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Auto auto)//agregar un auto
        {
            Context.Autos.Add(auto);
            Context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerAuto", new { id = auto.Id }, auto);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Auto value)
        {
            if (id != value.Id)
            {
                BadRequest();
            }
            Context.Entry(value).State = EntityState.Modified;
            Context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Auto> Delete(int id)
        {
            var resultado = Context.Autos.FirstOrDefault(x => x.Id ==
            id);
            if (resultado == null)
            { return NotFound(); }
            Context.Autos.Remove(resultado);
            Context.SaveChanges();
            return resultado;
        }
    }
}
