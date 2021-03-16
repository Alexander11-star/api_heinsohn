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
    public class ProductoController : ControllerBase
    {
        public AppDbContext Context { get; }

        public ProductoController(AppDbContext context)
        {
            Context = context;
        }

        // GET 
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return Context.Producto.ToList();
        }

        // GET api/values
        [HttpGet("{id}")]
        public Producto Get(int id)
        {
            var producto = Context.Producto.FirstOrDefault(p=>p.idProducto==id);
            return producto;
        }

        // POST api/value - insert
        [HttpPost]
        public ActionResult Post([FromBody]Producto producto  )
        {
            try
            {
                Context.Producto.Add(producto);
                Context.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }   
        }

        // PUT api/value/5 - update
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Producto producto)
        {
            if(producto.idProducto == id)
            {
                Context.Entry(producto).State = EntityState.Modified;
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
            var producto = Context.Producto.FirstOrDefault(p => p.idProducto == id);
            if(producto != null )
            {
                Context.Producto.Remove(producto);
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
