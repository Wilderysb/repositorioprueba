using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Engage3.Models
{
    public class BUSQUEDA_RESPUESTA
    {
        [Key]
        public int CONDICION { get; set; }
        public string ESTADO { get; set; }
        public string SUBESTADO { get; set; }
    }
}
