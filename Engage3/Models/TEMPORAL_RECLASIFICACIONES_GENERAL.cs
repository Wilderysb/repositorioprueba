using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Engage3.Models
{
    public class TEMPORAL_RECLASIFICACIONES_GENERAL
    {
        [Key]
        public int ID_RECLA { get; set; }
        public Guid ID_CARGA { get; set; }
        public string NUM_TICKET { get; set; }
        public string NUEVO_TIPO { get; set; }
        public string NUEVO_PRODUCTO { get; set; }
        public string NUEVO_SUBPRODUCTO { get; set; }
        public string NUEVO_MOTIVO { get; set; }
        public string NUEVO_SUBMOTIVO { get; set; }
        public string NUEVO_CODIGO_SBS_SP { get; set; }
        public string NUEVO_CODIGO_SBS_SM { get; set; }
        public string NUEVO_CANAL_INGRESO { get; set; }
        public string NUEVA_TIENDA { get; set; }
        public string NUEVA_FECHA_SOLICITUD { get; set; }
        public string USUARIO_CARGA { get; set; }
        public string FECHA_INICIO_CARGA { get; set; }
        public string FECHA_FIN_CARGA { get; set; }
        public string PASA_FASE { get; set; }
    }
}
