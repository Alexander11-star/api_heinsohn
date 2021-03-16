using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_RESTFull_crud.Context;
using API_RESTFull_crud.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_RESTFull_crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        public AppDbContext Context { get; }

        public CategoriaController(AppDbContext context)
        {
            Context = context;
        }

        // GET 
        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            return Context.Categoria.ToList();
        }

        // GET api/values
        [HttpGet("{id}")]
        public Categoria Get(int id)
        {
            var categoria = Context.Categoria.FirstOrDefault(p=>p.idCategoria==id);
            return categoria;
        }

        // POST api/value - insert
        [HttpPost]
        public ActionResult Post([FromBody]Categoria categoria  )
        {
            try
            {
                Context.Categoria.Add(categoria);
                Context.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }   
        }

        // PUT api/value/ - update
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Categoria categoria)
        {
            if(categoria.idCategoria == id)
            {
                Context.Entry(categoria).State = EntityState.Modified;
                Context.SaveChanges();
                return Ok();
            }
            else 
            {
                return BadRequest();
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var categoria = Context.Categoria.FirstOrDefault(p => p.idCategoria == id);
            if(categoria != null )
            {
                Context.Categoria.Remove(categoria);
                Context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }


    }
}
