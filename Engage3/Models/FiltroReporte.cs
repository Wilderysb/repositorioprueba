using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Engage3.Models
{
    public class FiltroReporte
    {
        [Key]
        public int id { get; set; }

        public Guid ID_CARGA { get; set; }

        public int NUMERO_VEZ { get; set; }

    }
}
