using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_RESTFull_crud.Entities
{
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }
        public string nombreCategoria { get; set; }
    }
}
