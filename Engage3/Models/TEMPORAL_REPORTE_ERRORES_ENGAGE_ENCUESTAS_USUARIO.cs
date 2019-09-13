using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Engage3.Models
{
    public class TEMPORAL_REPORTE_ERRORES_ENGAGE_ENCUESTAS_USUARIO
    {
        [Key]
        [DisplayName("Numero de Registro")]
        public int ID_ERROR { get; set; }
        [DisplayName("ID")]
        public Guid ID_CARGA { get; set; }
        [DisplayName("Numero de Ticket")]
        public string NUM_TICKET { get; set; }
        [DisplayName("Email")]
        public string CORREO { get; set; }
        [DisplayName("Fecha de Solicitud")]
        public string FEC_SOLICITUD { get; set; }
        [DisplayName("Tipo de Encuesta")]
        public string TIP_ENCUESTA { get; set; }
        [DisplayName("Estado de Encuesta")]
        public string EST_ENCUESTA { get; set; }
        [DisplayName("Usuario de Carga")]
        public string USUARIO_CARGA { get; set; }
        [DisplayName("Fecha Inicio de La Carga")]
        public string FECHA_INICIO_CARGA { get; set; }
        [DisplayName("Estado Fin de la Carga")]
        public string FECHA_FIN_CARGA { get; set; }
        [DisplayName("Estado Final del Registro")]
        public string PASA_FASE { get; set; }
    }
}
