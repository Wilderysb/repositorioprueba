using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Engage3.Models
{
    public class TMT_REQUERIMIENTO_GENERAL
    {
        [Key]
        [Column(Order =1)]
        public int    ID_GENERAL{ get; set; }      
        [Column(Order =2)]
        public Guid   ID_CARGA { get; set; }
        [Column(Order = 3)]
        public string NUMERO_TICKET { get; set; }
        [Column(Order =4)]
        public string ESTADO { get; set; }
        [Column(Order = 5)]
        public string SUB_ESTADO { get; set; }
        [Column(Order = 6)]
        public string RESOLUTOR { get; set; }
        [Column(Order = 7)]
        public string ACCION { get; set; }
        [Column(Order = 8)]
        public string FECHA_ACCION { get; set; }
        [Column(Order = 9)]
        public string RESOLUTOR_AJUSTE { get; set; }
        [Column(Order = 10)]
        public string FECHA_AJUSTE { get; set; }
        [Column(Order = 11)]
        public string TIPO_AJUSTE { get; set; }
        [Column(Order = 12)]
        public string MONEDA { get; set; }
        [Column(Order = 13)]
        public string CAPITAL { get; set; }
        [Column(Order = 14)]
        public string INTERESES { get; set; }
        [Column(Order = 15)]
        public string TOTAL { get; set; }
        [Column(Order = 16)]
        public string CENTRO_COSTOS { get; set; }
        [Column(Order = 17)]
        public string RESULTADOS_PROCEDE { get; set; }
        [Column(Order = 18)]
        public string MOTIVO_RESULTADO { get; set; }
        [Column(Order = 19)]
        public string PRIMERA_FECHA_PASE_PROCEDE { get; set; }
        [Column(Order = 20)]
        public string PRIMERA_FECHA_PASE_EN_COMUNICACION { get; set; }
        [Column(Order = 21)]
        public string PRIMERA_FECHA_PASE_NOTIFICADO { get; set; }
        [Column(Order = 22)]
        public string FECHA_BITACORA { get; set; }
        [Column(Order = 23)]
        public string AGENTE_BITACORA { get; set; }
        [Column(Order = 24)]
        public string COMENTARIO_BITACORA { get; set; }
        [Column(Order = 25)]
        public string CARTAS_ENVIADAS { get; set; }
        [Column(Order = 26)]
        public string FECHA_CARTA_ENVIADA { get; set; }
        [Column(Order = 27)]
        public string AGENTE_CARTA_ENVIADA { get; set; }
        [Column(Order = 28)]
        public string FECHA_ENTREGA_CARGO { get; set; }
        [Column(Order = 29)]
        public string RECIBIDO_POR { get; set; }
        [Column(Order = 30)]
        public string DNI { get; set; }
        [Column(Order = 31)]
        public string RELACION_TITULAR { get; set; }
        [Column(Order = 32)]
        public string OBSERVACIONES { get; set; }
        [Column(Order = 33)]
        public string CMASIVO { get; set; }
        [Column(Order = 34)]
        public string USUARIO_CARGA { get; set; }
        [Column(Order = 35)]
        public DateTime FECHA_INICIO_CARGA { get; set; }
        [Column(Order = 36)]
        public DateTime FECHA_FIN_CARGA { get; set; }
        [Column(Order = 37)]
        public string PASA_FASE { get; set; }


    }
}
