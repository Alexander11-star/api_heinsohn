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
    public class ClienteController : ControllerBase
    {
        public AppDbContext Context { get; }

        public ClienteController(AppDbContext context)
        {
            Context = context;
        }

        // GET 
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return Context.Cliente.ToList();
        }

        // GET api/values
        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            var cliente = Context.Cliente.FirstOrDefault(p=>p.idCliente==id);
            return cliente;
        }

        // POST api/value - insert
        [HttpPost]
        public ActionResult Post([FromBody]Cliente cliente )
        {
            try
            {
                Context.Cliente.Add(cliente);
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
        public ActionResult Put(int id, [FromBody] Cliente cliente)
        {
            if(cliente.idCliente == id)
            {
                Context.Entry(cliente).State = EntityState.Modified;
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
            var cliente = Context.Cliente.FirstOrDefault(p => p.idCliente == id);
            if(cliente != null )
            {
                Context.Cliente.Remove(cliente);
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
