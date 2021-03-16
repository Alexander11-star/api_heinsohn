using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_RESTFull_crud.Entities
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }
        //[Required(ErrorMessage =)]
        public string nombreProducto { get; set; }
        public int precio { get; set; }
        public int idCategoria { get; set; }

      
    }
}
