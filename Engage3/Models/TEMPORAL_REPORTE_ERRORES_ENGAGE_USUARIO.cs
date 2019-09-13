using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Engage3.Models
{
    public class TEMPORAL_REPORTE_ERRORES_ENGAGE_USUARIO
    {
        [Key]
        [DisplayName("Numero de Registro")]
        public int ID_ERROR { get; set; }
        [DisplayName("Numero de Ticket")]
        public string TICKET { get; set; }
        [DisplayName("Estado RQ")]
        public string ESTADO { get; set; }
        [DisplayName("SubEstado RQ")]
        public string SUBESTADO { get; set; }
        [DisplayName("Resolutor")]
        public string ID_RESOLUTOR { get; set; }
        [DisplayName("Accion")]
        public string ACCION { get; set; }
        [DisplayName("Fecha de Accion")]
        public string FECHA_ACCION { get; set; }
        [DisplayName("Resolutor (Ajuste)")]
        public string RESOLUTOR_AJUSTE { get; set; }
        [DisplayName("Fecha (de Ajuste)")]
        public string FECHA_AJUSTE { get; set; }
        [DisplayName("Tipo Ajuste")]
        public string TIPO_AJUSTE { get; set; }
        [DisplayName("Moneda")]
        public string MONEDA { get; set; }
        [DisplayName("Capital")]
        public string CAPITAL { get; set; }
        [DisplayName("Intereses")]
        public string INTERESES { get; set; }
        [DisplayName("Total")]
        public string TOTAL { get; set; }
        [DisplayName("Centro Costos")]        
        public string CENTRO_COSTOS { get; set; }
        [DisplayName("Resultado")]
        public string RESULTADO { get; set; }
        [DisplayName("Motivo resultado")]
        public string MOTIVO_RESULTADO { get; set; }
        [DisplayName("1ra fecha de pase a procede o no procede")]
        public string PRIMERA_FECHA_PASE_PROCEDE { get; set; }
        [DisplayName("1era fecha de pase a en comunicación")]
        public string PRIMERA_FECHA_PASE_EN_COMUNICACION { get; set; }
        [DisplayName("1era fecha de pase a notificado")]
        public string PRIMERA_FECHA_PASE_NOTIFICADO { get; set; }
        [DisplayName("Fecha de Bitácora")]
        public string FECHA_BITACORA { get; set; }
        [DisplayName("Agente (Bitácora)")]
        public string AGENTE_BITACORA { get; set; }
        [DisplayName("Comentario(Bitácora)")]        
        public string COMENTARIO_BITACORA { get; set; }
        [DisplayName("Cartas Enviadas (campo carta)")]
        public string CARTAS_ENVIADAS { get; set; }
        [DisplayName("Fecha Carta Enviada")]
        public string FECHA_CARTA_ENVIADA { get; set; }
        [DisplayName("Agente Carta Enviada")]
        public string AGENTE_CARTA_ENVIADA { get; set; }
        [DisplayName("Fecha entrega (Cargo de recepción)")]
        public string FECHA_ENTREGA_CARGO { get; set; }
        [DisplayName("Recibido por")]        
        public string RECIBIDO_POR { get; set; }
        [DisplayName("DNI")]
        public string DNI { get; set; }
        [DisplayName("Relación titular")]
        public string RELACION_TITULAR { get; set; }
        [DisplayName("Observaciones")]
        public string OBSERVACIONES { get; set; }
        [DisplayName("Validacion de Fecha Rango Entrega - Notificado")]
        public string VALIDA_RANGO_ENT_NOT { get; set; }
        [DisplayName("Validacion de Fecha Rango Notificado - Solicitud")]
        public string VALIDA_RANGO_NOT_SOL { get; set; }
        [DisplayName("Validacion de Fecha en relacion Fecha Entrega")]
        public string VALIDA_RANGO_ALL_ENTREGA { get; set; }
        [DisplayName("Estado Final del Registro")]
        public string PASA_FASE { get; set; }
    }
}
