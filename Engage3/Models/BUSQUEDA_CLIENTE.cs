using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Engage3.Models
{
    public class BUSQUEDA_CLIENTE
    {
        [Key]
        public int CONDICION { get; set; }
        public string APPATERNO { get; set; }
        public string APMATERNO { get; set; }
        public string NOMBRES { get; set; }
        public string DIRECCION { get; set; }

    }
}
