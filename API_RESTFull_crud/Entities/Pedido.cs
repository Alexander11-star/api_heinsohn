using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_RESTFull_crud.Entities
{
    public class Pedido
    {
        [Key]
        public int idPedido { get; set; }
        public int idProducto { get; set; }
        public int idCliente { get; set; }
        public string fechaPedido { get; set; }
        public int cantidad { get; set; }
        public int precio { get; set; }
        public int idCategoria { get; set; }
        public string comentario { get; set; }
    }
}
