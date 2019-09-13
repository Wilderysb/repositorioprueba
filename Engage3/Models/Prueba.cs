using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Engage3.Models
{
    public class Prueba
    {
        [Key]
        public int id { get; set; }
        public decimal descripcion { get; set; }
    }
}
