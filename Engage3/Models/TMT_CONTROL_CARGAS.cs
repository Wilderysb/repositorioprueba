using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Engage3.Models
{
    public class TMT_CONTROL_CARGAS
    {
        [Key]
        public int ID_CONTROL { get; set; }
        public Guid? ID_CARGA { get; set; }
        public DateTime? DIA_EJECUCION { get; set; }
        public string USUARIO { get; set; }
        public string NOMBRE_DOCUMENTO { get; set; }
        public int? NUMERO_VEZ { get; set; }
    }
}
