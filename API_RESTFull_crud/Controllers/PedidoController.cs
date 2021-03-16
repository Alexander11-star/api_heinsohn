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
    public class PedidoController : ControllerBase
    {
        public AppDbContext Context { get; }

        public PedidoController(AppDbContext context)
        {
            Context = context;
        }

        // GET 
        [HttpGet]
        public IEnumerable<Pedido> Get()
        {
            return Context.Pedido.ToList();
        }

        // GET api/values
        [HttpGet("{id}")]
        public Pedido Get(int id)
        {
            var pedido = Context.Pedido.FirstOrDefault(p => p.idCliente == id);
            return pedido;
        }

        // GET api/values


        [HttpGet]
        [Route("getid/{id}")]
        public Pedido Getfilter(int id)
        {
            var pedido = Context.Pedido.FirstOrDefault(p => p.idPedido == id);
            return pedido;
        }


        // POST api/value - insert
        [HttpPost]
        public ActionResult Post([FromBody]Pedido pedido)
        {
            try
            {
                Context.Pedido.Add(pedido);
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
        public ActionResult Put(int id, [FromBody] Pedido pedido)
        {
            if(pedido.idPedido == id)
            {
                Context.Entry(pedido).State = EntityState.Modified;
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
            var pedido = Context.Pedido.FirstOrDefault(p => p.idPedido == id);
            if(pedido != null )
            {
                Context.Pedido.Remove(pedido);
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
