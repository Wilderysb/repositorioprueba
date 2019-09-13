using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Engage3.Models
{
    public class TEMPORAL_REPORTE_ERRORES_ENGAGE
    {
        [Key]
        public int ID_ERROR { get; set; }
        public int ID_GENERAL { get; set; }
        public Guid ID_CARGA { get; set; }
        public string TICKET { get; set; }
        public string ESTADO { get; set; }
        public string SUBESTADO { get; set; }
        public string ID_RESOLUTOR { get; set; }
        public string ACCION { get; set; }
        public string FECHA_ACCION { get; set; }
        public string RESOLUTOR_AJUSTE { get; set; }
        public string FECHA_AJUSTE { get; set; }
        public string TIPO_AJUSTE { get; set; }
        public string MONEDA { get; set; }
        public string CAPITAL { get; set; }
        public string INTERESES { get; set; }
        public string TOTAL { get; set; }
        public string CENTRO_COSTOS { get; set; }
        public string RESULTADO { get; set; }
        public string MOTIVO_RESULTADO { get; set; }
        public string PRIMERA_FECHA_PASE_PROCEDE { get; set; }
        public string PRIMERA_FECHA_PASE_EN_COMUNICACION { get; set; }
        public string PRIMERA_FECHA_PASE_NOTIFICADO { get; set; }
        public string FECHA_BITACORA { get; set; }
        public string AGENTE_BITACORA { get; set; }
        public string COMENTARIO_BITACORA { get; set; }
        public string CARTAS_ENVIADAS { get; set; }
        public string FECHA_CARTA_ENVIADA { get; set; }
        public string AGENTE_CARTA_ENVIADA { get; set; }
        public string FECHA_ENTREGA_CARGO { get; set; }
        public string RECIBIDO_POR { get; set; }
        public string DNI { get; set; }
        public string RELACION_TITULAR { get; set; }
        public string OBSERVACIONES { get; set; }
        public string VALIDA_RANGO_ENT_NOT { get; set; }
        public string VALIDA_RANGO_NOT_SOL { get; set; }
        public string VALIDA_RANGO_ALL_ENTREGA { get; set; }
        public string USUARIO_CARGA { get; set; }
        public DateTime FECHA_INICIO_CARGA { get; set; }
        public DateTime FECHA_FIN_CARGA { get; set; }
        public string PASA_FASE { get; set; }

    }


}
