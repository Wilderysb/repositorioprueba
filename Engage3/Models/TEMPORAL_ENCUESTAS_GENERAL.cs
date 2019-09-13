using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Engage3.Models
{
    public class TEMPORAL_ENCUESTAS_GENERAL
    {
        [Key]
        public int ID_GENERAL { get; set; }

        public Guid ID_CARGA { get; set; }

        public string NUM_TICKET { get; set; }

        public string CORREO { get; set; }

        public string FEC_SOLICITUD { get; set; }

        public string TIP_ENCUESTA { get; set; }

        public string EST_ENCUESTA { get; set; }

        public string USUARIO_CARGA  { get; set; }

        public string FECHA_INICIO_CARGA { get; set; }

        public string FECHA_FIN_CARGA { get; set; }

        public string PASA_FASE { get; set; }

    }
}

