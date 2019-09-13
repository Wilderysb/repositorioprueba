using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Engage3.Models
{
    public class ENG_PARAMETRO_DET
    {
        [Key]
        public int COD_PARAM_DET { get; set; }
        public string GLS_PARAM_DET { get; set; }
        public string VALOR_PARAM_DET { get; set; }
        public int COD_PARAM_CAB { get; set; }
        public string USUARIOCREACION_ID { get; set; }
        public DateTime CREACION_FE { get; set; }
        public string USUARIOACTUALIZACION_ID { get; set; }
        public DateTime? ACTUALIZACION_FE { get; set; }
        public string USUARIOELIMINACION_ID { get; set; }
        public DateTime? ELIMINACION_FE { get; set; }
        public bool EST_ACTIVO_FL { get; set; }
    }
}
