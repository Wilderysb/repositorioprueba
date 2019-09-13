using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;
using Engage3.Data;
using Engage3.Models;
using FastMember;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;

namespace Engage3.Controllers
{
    [Produces("application/json")]
    [Route("api/EPPlus")]
    public class EPPlusController : Controller
    {
        private readonly TmtGeneralContext _db;

        private readonly IConfiguration _conf;

        private readonly ISession session;

        public EPPlusController(TmtGeneralContext db, IConfiguration conf, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _conf = conf;
            session = httpContextAccessor.HttpContext.Session;
        }

        [HttpPost("import")]
        public async Task<DemoResponse<List<Models.TMT_REQUERIMIENTO_GENERAL>>> Import(IFormFile formFile, CancellationToken cancellationToken,string nombreDocumento)
        {
            Guid idCarga = Guid.NewGuid();

            //var USUARIO = ViewBag["Usuario"];

            var x = formFile;
           
            var UsuarioSession = HttpContext.Session.GetString("Usuario");

            if (formFile == null || formFile.Length <= 0)
            {
                return DemoResponse<List<Models.TMT_REQUERIMIENTO_GENERAL>>.GetResult(-1, "formfile is empty");
            }

            if (!Path.GetExtension(formFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return DemoResponse<List<Models.TMT_REQUERIMIENTO_GENERAL>>.GetResult(-1, "Not Support file extension");
            }

            var lista = new List<Models.TMT_REQUERIMIENTO_GENERAL>();

            var estructuraCierre = new List<string>();

             string[] estructuraCierreDefinida = new string[] { "NUMERO DE TICKET", "ESTADO", "SUB ESTADO", "RESOLUTOR"
            , "ACCION", "FECHA DE ACCION", "RESOLUTOR DE AJUSTE", "FECHA DE AJUSTE", "TIPO DE AJUSTE", "MONEDA", "CAPITAL", "INTERESES"
            , "TOTAL", "CENTRO DE COSTOS", "RESULTADOS PROCEDE O NO PROCEDE", "MOTIVO RESULTADO", "1ERA FECHA PASE PROCEDE O NO PROCEDE", "1ERA FECHA DE PASE A EN COMUNICACIÓN"
            ,"1ERA FECHA DE PASE A NOTIFICADO", "FECHA DE BITACORA", "AGENTE BITACORA", "COMENTARIO BITACORA", "CARTAS ENVIADAS", "FECHA CARTA ENVIADA", "AGENTE CARTA ENVIADA", "FECHA ENTREGA CARGO POR RECEPCION"
            , "RECIBIDO POR", "DNI", "RELACION TITULAR", "OBSERVACIONES","CMASIVO"};


            using (var stream = new MemoryStream())
            {
                await formFile.CopyToAsync(stream, cancellationToken);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    var columnCount = worksheet.Dimension.Columns;

                    var numero_ticket = "";
                    var estado = "";
                    var sub_estado = "";
                    var resolutor = "";
                    var accion = "";
                    var fecha_accion = "";
                    var resolutor_ajuste = "";
                    var fecha_ajuste = "";
                    var tipo_ajuste = "";
                    var moneda = "";
                    var capital = "";
                    var intereses = "";
                    var total = "";
                    var centro_costos = "";
                    var resultados_procede = "";
                    var motivo_resultado = "";
                    var primera_fecha_pase_procede = "";
                    var primera_fecha_pase_en_comunicacion = "";
                    var primera_fecha_pase_notificado = "";
                    var fecha_bitacora = "";
                    var agente_bitacora = "";
                    var comentario_bitacora = "";
                    var cartas_enviadas = "";
                    var fecha_carta_enviada = "";
                    var agente_carta_enviada = "";
                    var fecha_entrega_cargo = "";
                    var recibido_por = "";
                    var dni = "";
                    var relacion_titular = "";
                    var observaciones = "";
                    var cmasivo = "";
                    
            


                    for (int row = 1; row <= columnCount; row++)
                    {
                        estructuraCierre.Add(worksheet.Cells[1, row].Value.ToString().Trim());
                    }

                    var estructuraCierreArray = estructuraCierre.ToArray();

                    bool estructura = estructuraCierreDefinida.SequenceEqual(estructuraCierreArray);

                    if (estructura == false)
                    {

                        return DemoResponse<List<Models.TMT_REQUERIMIENTO_GENERAL>>.GetResult(-1, "Estructura No Valida");
                    }


                    for (int row = 2; row <= rowCount; row++)
                    {

                        try
                        {

                            try
                            {
                                if (worksheet.Cells[row, 1].Value != null) { numero_ticket = worksheet.Cells[row, 1].Value.ToString(); }
                                else { numero_ticket = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 2].Value != null) { estado = worksheet.Cells[row, 2].Value.ToString(); }
                                else { estado = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 3].Value != null) { sub_estado = worksheet.Cells[row, 3].Value.ToString(); }
                                else { sub_estado = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 4].Value != null) { resolutor = worksheet.Cells[row, 4].Value.ToString(); }
                                else { resolutor = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 5].Value != null) { accion = worksheet.Cells[row, 5].Value.ToString(); }
                                else { accion = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 6].Value != null) { fecha_accion = worksheet.Cells[row, 6].Value.ToString(); }
                                else { fecha_accion = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 7].Value != null) { resolutor_ajuste = worksheet.Cells[row, 7].Value.ToString(); }
                                else { resolutor_ajuste = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 8].Value != null) { fecha_ajuste = worksheet.Cells[row, 8].Value.ToString(); }
                                else { fecha_ajuste = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 9].Value != null) { tipo_ajuste = worksheet.Cells[row, 9].Value.ToString(); }
                                else { tipo_ajuste = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 10].Value != null) { moneda = worksheet.Cells[row, 10].Value.ToString(); }
                                else { moneda = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 11].Value != null) { capital = worksheet.Cells[row, 11].Value.ToString(); }
                                else { capital = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 12].Value != null) { intereses = worksheet.Cells[row, 12].Value.ToString(); }
                                else { intereses = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 13].Value != null) { total = worksheet.Cells[row, 13].Value.ToString(); }
                                else { total = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 14].Value != null) { centro_costos = worksheet.Cells[row, 14].Value.ToString(); }
                                else { centro_costos = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 15].Value != null) { resultados_procede = worksheet.Cells[row, 15].Value.ToString(); }
                                else { resultados_procede = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 16].Value != null) { motivo_resultado = worksheet.Cells[row, 16].Value.ToString(); }
                                else { motivo_resultado = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 17].Value != null) { primera_fecha_pase_procede = worksheet.Cells[row, 17].Value.ToString(); }
                                else { primera_fecha_pase_procede = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 18].Value != null) { primera_fecha_pase_en_comunicacion = worksheet.Cells[row, 18].Value.ToString(); }
                                else { primera_fecha_pase_en_comunicacion = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 19].Value != null) { primera_fecha_pase_notificado = worksheet.Cells[row, 19].Value.ToString(); }
                                else { primera_fecha_pase_notificado = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 20].Value != null) { fecha_bitacora = worksheet.Cells[row, 20].Value.ToString(); }
                                else { fecha_bitacora = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 21].Value != null) { agente_bitacora = worksheet.Cells[row, 21].Value.ToString(); }
                                else { agente_bitacora = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 22].Value != null) { comentario_bitacora = worksheet.Cells[row, 22].Value.ToString(); }
                                else { comentario_bitacora = ""; }
                            }
                            catch (Exception ex)
                            { }


                            try
                            {
                                if (worksheet.Cells[row, 23].Value != null) { cartas_enviadas = worksheet.Cells[row, 23].Value.ToString(); }
                                else { cartas_enviadas = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 24].Value != null) { fecha_carta_enviada = worksheet.Cells[row, 24].Value.ToString(); }
                                else { fecha_carta_enviada = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 25].Value != null) { agente_carta_enviada = worksheet.Cells[row, 25].Value.ToString(); }
                                else { agente_carta_enviada = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 26].Value != null) { fecha_entrega_cargo = worksheet.Cells[row, 26].Value.ToString(); }
                                else { fecha_entrega_cargo = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 27].Value != null) { recibido_por = worksheet.Cells[row, 27].Value.ToString(); }
                                else { recibido_por = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 28].Value != null) { dni = worksheet.Cells[row, 28].Value.ToString(); }
                                else { dni = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 29].Value != null) { relacion_titular = worksheet.Cells[row, 29].Value.ToString(); }
                                else { relacion_titular = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 30].Value != null) { observaciones = worksheet.Cells[row, 30].Value.ToString(); }
                                else { observaciones = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 31].Value != null) { cmasivo = worksheet.Cells[row, 31].Value.ToString(); }
                                else { cmasivo = ""; }
                            }
                            catch (Exception ex)
                            { }

                            if (UsuarioSession is null || UsuarioSession == "") { UsuarioSession = ""; }

                            lista.Add(new Models.TMT_REQUERIMIENTO_GENERAL
                            {
                                ID_CARGA = idCarga,
                                NUMERO_TICKET = numero_ticket.ToString().Trim(),
                                ESTADO = estado.ToString().Trim(),
                                SUB_ESTADO = sub_estado.ToString().Trim(),
                                RESOLUTOR = resolutor.ToString().Trim(),
                                ACCION = accion.ToString().Trim(),
                                FECHA_ACCION = fecha_accion.ToString().Trim(),
                                RESOLUTOR_AJUSTE = resolutor_ajuste.ToString().Trim(),
                                FECHA_AJUSTE = fecha_ajuste.ToString().Trim(),
                                TIPO_AJUSTE = tipo_ajuste.ToString().Trim(),
                                MONEDA = moneda.ToString().Trim(),
                                CAPITAL = capital.ToString().Trim(),
                                INTERESES = intereses.ToString().Trim(),
                                TOTAL = total.ToString().Trim(),
                                CENTRO_COSTOS = centro_costos.ToString().Trim(),
                                RESULTADOS_PROCEDE = resultados_procede.ToString().Trim(),
                                MOTIVO_RESULTADO = motivo_resultado.ToString().Trim(),
                                PRIMERA_FECHA_PASE_PROCEDE = primera_fecha_pase_procede.ToString().Trim(),
                                PRIMERA_FECHA_PASE_EN_COMUNICACION = primera_fecha_pase_en_comunicacion.ToString().Trim(),
                                PRIMERA_FECHA_PASE_NOTIFICADO = primera_fecha_pase_notificado.ToString().Trim(),
                                FECHA_BITACORA = fecha_bitacora.ToString().Trim(),
                                AGENTE_BITACORA = agente_bitacora.ToString().Trim(),
                                COMENTARIO_BITACORA = comentario_bitacora.ToString().Trim(),
                                CARTAS_ENVIADAS = cartas_enviadas.ToString().Trim(),
                                FECHA_CARTA_ENVIADA = fecha_carta_enviada.ToString().Trim(),
                                AGENTE_CARTA_ENVIADA = agente_carta_enviada.ToString().Trim(),
                                FECHA_ENTREGA_CARGO = fecha_entrega_cargo.ToString().Trim(),
                                RECIBIDO_POR = recibido_por.ToString().Trim(),
                                DNI = dni.ToString().Trim(),
                                RELACION_TITULAR = relacion_titular.ToString().Trim(),
                                OBSERVACIONES = observaciones.ToString().Trim(),
                                USUARIO_CARGA = UsuarioSession,
                                FECHA_INICIO_CARGA = DateTime.Now,
                                FECHA_FIN_CARGA = DateTime.Now,
                                CMASIVO=cmasivo.ToString().Trim()
                            });
                        }
                        catch (Exception ex) { }

                    }


                }
            }

            var copyParameters = new[]
            {
                nameof(TMT_REQUERIMIENTO_GENERAL.ID_GENERAL),
                nameof(TMT_REQUERIMIENTO_GENERAL.ID_CARGA),
                nameof(TMT_REQUERIMIENTO_GENERAL.NUMERO_TICKET),
                nameof(TMT_REQUERIMIENTO_GENERAL.ESTADO),
                nameof(TMT_REQUERIMIENTO_GENERAL.SUB_ESTADO),
                nameof(TMT_REQUERIMIENTO_GENERAL.RESOLUTOR),
                nameof(TMT_REQUERIMIENTO_GENERAL.ACCION),
                nameof(TMT_REQUERIMIENTO_GENERAL.FECHA_ACCION),
                nameof(TMT_REQUERIMIENTO_GENERAL.RESOLUTOR_AJUSTE),
                nameof(TMT_REQUERIMIENTO_GENERAL.FECHA_AJUSTE),
                nameof(TMT_REQUERIMIENTO_GENERAL.TIPO_AJUSTE),
                nameof(TMT_REQUERIMIENTO_GENERAL.MONEDA),
                nameof(TMT_REQUERIMIENTO_GENERAL.CAPITAL),
                nameof(TMT_REQUERIMIENTO_GENERAL.INTERESES),
                nameof(TMT_REQUERIMIENTO_GENERAL.TOTAL),
                nameof(TMT_REQUERIMIENTO_GENERAL.CENTRO_COSTOS),
                nameof(TMT_REQUERIMIENTO_GENERAL.RESULTADOS_PROCEDE),
                nameof(TMT_REQUERIMIENTO_GENERAL.MOTIVO_RESULTADO),
                nameof(TMT_REQUERIMIENTO_GENERAL.PRIMERA_FECHA_PASE_PROCEDE),
                nameof(TMT_REQUERIMIENTO_GENERAL.PRIMERA_FECHA_PASE_EN_COMUNICACION),
                nameof(TMT_REQUERIMIENTO_GENERAL.PRIMERA_FECHA_PASE_NOTIFICADO),
                nameof(TMT_REQUERIMIENTO_GENERAL.FECHA_BITACORA),
                nameof(TMT_REQUERIMIENTO_GENERAL.AGENTE_BITACORA),
                nameof(TMT_REQUERIMIENTO_GENERAL.COMENTARIO_BITACORA),
                nameof(TMT_REQUERIMIENTO_GENERAL.CARTAS_ENVIADAS),
                nameof(TMT_REQUERIMIENTO_GENERAL.FECHA_CARTA_ENVIADA),
                nameof(TMT_REQUERIMIENTO_GENERAL.AGENTE_CARTA_ENVIADA),
                nameof(TMT_REQUERIMIENTO_GENERAL.FECHA_ENTREGA_CARGO),
                nameof(TMT_REQUERIMIENTO_GENERAL.RECIBIDO_POR),
                nameof(TMT_REQUERIMIENTO_GENERAL.DNI),
                nameof(TMT_REQUERIMIENTO_GENERAL.RELACION_TITULAR),
                nameof(TMT_REQUERIMIENTO_GENERAL.OBSERVACIONES),
                nameof(TMT_REQUERIMIENTO_GENERAL.CMASIVO),
                nameof(TMT_REQUERIMIENTO_GENERAL.USUARIO_CARGA),
                nameof(TMT_REQUERIMIENTO_GENERAL.FECHA_INICIO_CARGA),
                nameof(TMT_REQUERIMIENTO_GENERAL.FECHA_FIN_CARGA)
           };


            try
            {
                // using (var sqlCopy = new System.Data.SqlClient.SqlBulkCopy("Server=B1P081102;Database=FinancorReclamos1; Trusted_Connection=True; MultipleActiveResultSets=true"))
                using (var sqlCopy = new System.Data.SqlClient.SqlBulkCopy(_conf.GetConnectionString("Conexion01")))

                {
                    sqlCopy.DestinationTableName = "dbo.[TMT_REQUERIMIENTO_GENERAL]";
                    sqlCopy.BatchSize = 20000;
                    using (var reader = ObjectReader.Create(lista, copyParameters))
                    {
                        sqlCopy.WriteToServer(reader);
                    }

                }
                //var fecha = DateTime.Now;

               /// TEMPORAL

              
                var proceso = _db.Prueba.FromSql($"sp_Validacion_Componente {idCarga}").ToList();

                //var proceso2= _db.Prueba.FromSql($"sp_Insert_Control_Cargas {idCarga},{fecha},{UsuarioSession},{nombreDocumento},{0}").ToList();

                TMT_CONTROL_CARGAS objControlCargas = new TMT_CONTROL_CARGAS();
            
                objControlCargas.ID_CARGA = idCarga;
                objControlCargas.DIA_EJECUCION = DateTime.Now;
                objControlCargas.USUARIO = UsuarioSession;
                objControlCargas.NOMBRE_DOCUMENTO = nombreDocumento;
                objControlCargas.NUMERO_VEZ = 0;

                _db.Entry(objControlCargas).State = EntityState.Added;

                _db.SaveChanges();

            }
            catch (Exception ex)
            {

            }

            //Aqui debo procesar la Carga.           

            return DemoResponse<List<Models.TMT_REQUERIMIENTO_GENERAL>>.GetResult(0, "OK", lista);
        }

        [HttpPost("importencuesta")]
        public async Task<DemoResponse<List<Models.TEMPORAL_ENCUESTAS_GENERAL>>> ImportEncuesta(IFormFile formFile, CancellationToken cancellationToken,string nombreDocumento)
        {
            Guid idCarga = Guid.NewGuid();

            var UsuarioSession = HttpContext.Session.GetString("Usuario");

            if (formFile == null || formFile.Length <= 0)
            {
                return DemoResponse<List<Models.TEMPORAL_ENCUESTAS_GENERAL>>.GetResult(-1, "formfile is empty");
            }

            if (!Path.GetExtension(formFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return DemoResponse<List<Models.TEMPORAL_ENCUESTAS_GENERAL>>.GetResult(-1, "Not Support file extension");
            }

            var lista = new List<Models.TEMPORAL_ENCUESTAS_GENERAL>();

            var estructuraEncuesta = new List<string>();

            string[] estructuraEncuestaDefinida = new string[] { "NUM_TICKET", "CORREO", "FEC_SOLICITUD", "TIP_ENCUESTA"};

            using (var stream = new MemoryStream())
            {
                await formFile.CopyToAsync(stream, cancellationToken);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    var columnCount = worksheet.Dimension.Columns;

                    var numero_ticket = "";
                    var correo = "";
                    var fecha_solicitud = "";
                    var tip_encuesta = "";


                    for (int row = 1; row <= columnCount; row++)
                    {
                        estructuraEncuesta.Add(worksheet.Cells[1, row].Value.ToString().Trim());
                    }

                    var estructuraEncuestaArray = estructuraEncuesta.ToArray();

                    bool estructura = estructuraEncuestaDefinida.SequenceEqual(estructuraEncuestaArray);

                    if (estructura == false)
                    {

                        return DemoResponse<List<Models.TEMPORAL_ENCUESTAS_GENERAL>>.GetResult(-1, "Estructura No Valida");
                    }


                    for (int row = 2; row <= rowCount; row++)
                    {
                        try
                        {

                            try
                            {
                                if (worksheet.Cells[row, 1].Value != null) { numero_ticket = worksheet.Cells[row, 1].Value.ToString(); }
                                else { numero_ticket = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 2].Value != null) { correo = worksheet.Cells[row, 2].Value.ToString(); }
                                else { correo = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 3].Value != null) { fecha_solicitud = worksheet.Cells[row, 3].Value.ToString(); }
                                else { fecha_solicitud = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 4].Value != null) { tip_encuesta = worksheet.Cells[row, 4].Value.ToString(); }
                                else { tip_encuesta = ""; }
                            }
                            catch (Exception ex)
                            { }


                          
                            if (UsuarioSession is null || UsuarioSession == "") { UsuarioSession = ""; }

                            lista.Add(new Models.TEMPORAL_ENCUESTAS_GENERAL
                            {
                                ID_CARGA = idCarga,
                                NUM_TICKET = numero_ticket.ToString().Trim(),
                                CORREO = correo.ToString().Trim(),
                                FEC_SOLICITUD = fecha_solicitud.ToString(),
                                TIP_ENCUESTA = tip_encuesta.ToString().Trim(),
                                EST_ENCUESTA = null,
                                USUARIO_CARGA = UsuarioSession,
                                FECHA_INICIO_CARGA = DateTime.Now.ToString(),
                                FECHA_FIN_CARGA = DateTime.Now.ToString(),
                                PASA_FASE = ""
                            });
                        }
                        catch (Exception ex) { }

                    }
                }
            }

            var copyParameters = new[]
            {
                nameof(TEMPORAL_ENCUESTAS_GENERAL.ID_GENERAL),
                nameof(TEMPORAL_ENCUESTAS_GENERAL.ID_CARGA),
                nameof(TEMPORAL_ENCUESTAS_GENERAL.NUM_TICKET),
                nameof(TEMPORAL_ENCUESTAS_GENERAL.CORREO),
                nameof(TEMPORAL_ENCUESTAS_GENERAL.FEC_SOLICITUD),
                nameof(TEMPORAL_ENCUESTAS_GENERAL.TIP_ENCUESTA),
                nameof(TEMPORAL_ENCUESTAS_GENERAL.EST_ENCUESTA),
                nameof(TEMPORAL_ENCUESTAS_GENERAL.USUARIO_CARGA),
                nameof(TEMPORAL_ENCUESTAS_GENERAL.FECHA_INICIO_CARGA),
                nameof(TEMPORAL_ENCUESTAS_GENERAL.FECHA_FIN_CARGA),
                nameof(TEMPORAL_ENCUESTAS_GENERAL.PASA_FASE)

           };


            try
            {
                //using (var sqlCopy = new System.Data.SqlClient.SqlBulkCopy("Server=B1P081102;Database=FinancorReclamos1; Trusted_Connection=True; MultipleActiveResultSets=true"))
                using (var sqlCopy = new System.Data.SqlClient.SqlBulkCopy(_conf.GetConnectionString("Conexion01")))
                {
                    sqlCopy.DestinationTableName = "dbo.[TEMPORAL_ENCUESTAS_GENERAL]";
                    sqlCopy.BatchSize = 20000;
                    using (var reader = ObjectReader.Create(lista, copyParameters))
                    {
                        sqlCopy.WriteToServer(reader);
                    }

                }
                var proceso = _db.Prueba.FromSql($"sp_Validacion_Componente_Encuestas {idCarga}").ToList();
                //var proceso = _db.Prueba.FromSql($"sp_Validacion_Componente {idCarga}").ToList();
                //var proceso2 = _db.Prueba.FromSql($"sp_Insert_Control_Cargas {idCarga},{DateTime.Now},{UsuarioSession},{nombreDocumento},{0}").ToList();

                TMT_CONTROL_CARGAS objControlCargas = new TMT_CONTROL_CARGAS();

                objControlCargas.ID_CARGA = idCarga;
                objControlCargas.DIA_EJECUCION = DateTime.Now;
                objControlCargas.USUARIO = UsuarioSession;
                objControlCargas.NOMBRE_DOCUMENTO = nombreDocumento;
                objControlCargas.NUMERO_VEZ = 0;

                _db.Entry(objControlCargas).State = EntityState.Added;

                _db.SaveChanges();


            }
            catch (Exception ex)
            {

            }

            //Aqui debo procesar la Carga.           

            return DemoResponse<List<Models.TEMPORAL_ENCUESTAS_GENERAL>>.GetResult(0, "OK", lista);
        }

        [HttpPost("importreclasificaciones")]
        public async Task<DemoResponse<List<Models.TEMPORAL_RECLASIFICACIONES_GENERAL>>> ImportReclasificaciones(IFormFile formFile, CancellationToken cancellationToken, string nombreDocumento)
        {
            Guid idCarga = Guid.NewGuid();

            var UsuarioSession = HttpContext.Session.GetString("Usuario");

            if (formFile == null || formFile.Length <= 0)
            {
                return DemoResponse<List<Models.TEMPORAL_RECLASIFICACIONES_GENERAL>>.GetResult(-1, "formfile is empty");
            }

            if (!Path.GetExtension(formFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return DemoResponse<List<Models.TEMPORAL_RECLASIFICACIONES_GENERAL>>.GetResult(-1, "Not Support file extension");
            }

            var lista = new List<Models.TEMPORAL_RECLASIFICACIONES_GENERAL>();

            var estructuraReclasificaciones = new List<string>();

            string[] estructuraReclasificacionesDefinida = new string[] { "NUMERO_TICKET", "NUEVO_TIPO", "NUEVO_PRODUCTO"
            , "NUEVO_SUBPRODUCTO", "NUEVO_MOTIVO", "NUEVO_SUBMOTIVO", "NUEVO_CODIGO_SBS_SUBPRODUCTO", "NUEVO_CODIGO_SBS_SUBMOTIVO", "NUEVO_CANAL_INGRESO", "NUEVA_TIENDA", "NUEVA_FECHA_SOLICITUD"};

            using (var stream = new MemoryStream())
            {
                await formFile.CopyToAsync(stream, cancellationToken);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    var columnCount = worksheet.Dimension.Columns;

                    var numero_ticket = "";
                    var nuevo_tipo = "";
                    var nuevo_producto = "";
                    var nuevo_subproducto = "";
                    var nuevo_motivo = "";
                    var nuevo_submotivo = "";
                    var nuevo_codigosbs_subproducto = "";
                    var nuevo_codigosbs_submotivo = "";
                    var nuevo_canal_ingreso = "";
                    var nueva_fecha_solicitud = "";
                    var nueva_tienda = "";

                    for (int row = 1; row <= columnCount; row++)
                    {
                        estructuraReclasificaciones.Add(worksheet.Cells[1, row].Value.ToString().Trim());
                    }

                    var estructuraReclasificacionesArray = estructuraReclasificaciones.ToArray();

                    bool estructura = estructuraReclasificacionesDefinida.SequenceEqual(estructuraReclasificacionesArray);

                    if (estructura == false)
                    {

                        return DemoResponse<List<Models.TEMPORAL_RECLASIFICACIONES_GENERAL>>.GetResult(-1, "Estructura No Valida");
                    }

                    for (int row = 2; row <= rowCount; row++)
                    {
                        try
                        {

                            try
                            {
                                if (worksheet.Cells[row, 1].Value != null) { numero_ticket = worksheet.Cells[row, 1].Value.ToString(); }
                                else { numero_ticket = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 2].Value != null) { nuevo_tipo = worksheet.Cells[row, 2].Value.ToString(); }
                                else { nuevo_tipo = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 3].Value != null) { nuevo_producto = worksheet.Cells[row, 3].Value.ToString(); }
                                else { nuevo_producto = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 4].Value != null) { nuevo_subproducto = worksheet.Cells[row, 4].Value.ToString(); }
                                else { nuevo_subproducto = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 5].Value != null) { nuevo_motivo = worksheet.Cells[row, 5].Value.ToString(); }
                                else { nuevo_motivo = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 6].Value != null) { nuevo_submotivo = worksheet.Cells[row, 6].Value.ToString(); }
                                else { nuevo_submotivo = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 7].Value != null) { nuevo_codigosbs_subproducto = worksheet.Cells[row, 7].Value.ToString(); }
                                else { nuevo_codigosbs_subproducto = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 8].Value != null) { nuevo_codigosbs_submotivo = worksheet.Cells[row, 8].Value.ToString(); }
                                else { nuevo_codigosbs_submotivo = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 9].Value != null) { nuevo_canal_ingreso = worksheet.Cells[row, 9].Value.ToString(); }
                                else { nuevo_canal_ingreso = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 10].Value != null) { nueva_fecha_solicitud = worksheet.Cells[row, 10].Value.ToString(); }
                                else { nueva_fecha_solicitud = ""; }
                            }
                            catch (Exception ex)
                            { }

                            try
                            {
                                if (worksheet.Cells[row, 11].Value != null) { nueva_tienda = worksheet.Cells[row, 11].Value.ToString(); }
                                else { nueva_tienda = ""; }
                            }
                            catch (Exception ex)
                            { }


                            if (UsuarioSession is null || UsuarioSession == "") { UsuarioSession = ""; }

                            lista.Add(new Models.TEMPORAL_RECLASIFICACIONES_GENERAL
                            {
                                ID_CARGA = idCarga,
                                NUM_TICKET = numero_ticket.ToString().Trim(),
                                NUEVO_TIPO = nuevo_tipo.ToString().Trim(),
                                NUEVO_PRODUCTO = nuevo_producto.ToString().Trim(),
                                NUEVO_SUBPRODUCTO = nuevo_subproducto.ToString().Trim(),
                                NUEVO_MOTIVO = nuevo_motivo.ToString().Trim(),
                                NUEVO_SUBMOTIVO = nuevo_submotivo.ToString().Trim(),
                                NUEVO_CODIGO_SBS_SP = nuevo_codigosbs_subproducto.ToString().Trim(),
                                NUEVO_CODIGO_SBS_SM = nuevo_codigosbs_submotivo.ToString().Trim(),
                                NUEVO_CANAL_INGRESO = nuevo_canal_ingreso.ToString().Trim(),
                                NUEVA_FECHA_SOLICITUD = nueva_fecha_solicitud.ToString().Trim(),
                                NUEVA_TIENDA = nueva_tienda.ToString().Trim(),
                                USUARIO_CARGA = UsuarioSession,
                                FECHA_INICIO_CARGA = DateTime.Now.ToString(),
                                FECHA_FIN_CARGA = DateTime.Now.ToString(),
                                PASA_FASE = null
                            });
                        }
                        catch (Exception ex) { }

                    }
                }
            }

            var copyParameters = new[]
            {
                nameof(TEMPORAL_RECLASIFICACIONES_GENERAL.ID_RECLA),
                nameof(TEMPORAL_RECLASIFICACIONES_GENERAL.ID_CARGA),
                nameof(TEMPORAL_RECLASIFICACIONES_GENERAL.NUM_TICKET),
                nameof(TEMPORAL_RECLASIFICACIONES_GENERAL.NUEVO_TIPO),
                nameof(TEMPORAL_RECLASIFICACIONES_GENERAL.NUEVO_PRODUCTO),
                nameof(TEMPORAL_RECLASIFICACIONES_GENERAL.NUEVO_SUBPRODUCTO),
                nameof(TEMPORAL_RECLASIFICACIONES_GENERAL.NUEVO_MOTIVO),
                nameof(TEMPORAL_RECLASIFICACIONES_GENERAL.NUEVO_SUBMOTIVO),
                nameof(TEMPORAL_RECLASIFICACIONES_GENERAL.NUEVO_CODIGO_SBS_SP),
                nameof(TEMPORAL_RECLASIFICACIONES_GENERAL.NUEVO_CODIGO_SBS_SM),
                nameof(TEMPORAL_RECLASIFICACIONES_GENERAL.NUEVO_CANAL_INGRESO),
                nameof(TEMPORAL_RECLASIFICACIONES_GENERAL.NUEVA_FECHA_SOLICITUD),
                nameof(TEMPORAL_RECLASIFICACIONES_GENERAL.NUEVA_TIENDA),                
                nameof(TEMPORAL_RECLASIFICACIONES_GENERAL.USUARIO_CARGA),
                nameof(TEMPORAL_RECLASIFICACIONES_GENERAL.FECHA_INICIO_CARGA),
                nameof(TEMPORAL_RECLASIFICACIONES_GENERAL.FECHA_FIN_CARGA),
                nameof(TEMPORAL_RECLASIFICACIONES_GENERAL.PASA_FASE)
           };


            try
            {
                //using (var sqlCopy = new System.Data.SqlClient.SqlBulkCopy("Server=B1P081102;Database=FinancorReclamos1; Trusted_Connection=True; MultipleActiveResultSets=true"))
                using (var sqlCopy = new System.Data.SqlClient.SqlBulkCopy(_conf.GetConnectionString("Conexion01")))
                {
                    sqlCopy.DestinationTableName = "dbo.[TEMPORAL_RECLASIFICACIONES_GENERAL]";
                    sqlCopy.BatchSize = 20000;
                    using (var reader = ObjectReader.Create(lista, copyParameters))
                    {
                        sqlCopy.WriteToServer(reader);
                    }

                }
                var proceso = _db.Prueba.FromSql($"sp_Validacion_Componente_Reclasificaciones {idCarga}").ToList();

                //var proceso2 = _db.Prueba.FromSql($"sp_Insert_Control_Cargas {idCarga},{DateTime.Now},{UsuarioSession},{nombreDocumento},{0}").ToList();

                TMT_CONTROL_CARGAS objControlCargas = new TMT_CONTROL_CARGAS();

                objControlCargas.ID_CARGA = idCarga;
                objControlCargas.DIA_EJECUCION = DateTime.Now;
                objControlCargas.USUARIO = UsuarioSession;
                objControlCargas.NOMBRE_DOCUMENTO = nombreDocumento;
                objControlCargas.NUMERO_VEZ = 0;

                _db.Entry(objControlCargas).State = EntityState.Added;

                _db.SaveChanges();
                //var proceso = _db.Prueba.FromSql($"sp_Validacion_Componente {idCarga}").ToList();
            }
            catch (Exception ex)
            {

            }

            //Aqui debo procesar la Carga.           

            return DemoResponse<List<Models.TEMPORAL_RECLASIFICACIONES_GENERAL>>.GetResult(0, "OK", lista);
        }

        [HttpGet("DevuelveErrores")]
        public async Task<ReporteErroresResponse> DevuelveErrores(CancellationToken cancellationToken, DateTime fechaInicio, DateTime fechaFin,string tipCarga)
        {
            await Task.Yield();
            var UsuarioSession = HttpContext.Session.GetString("Usuario");

            var FechaInicio = fechaInicio;
            var FechaFin = fechaFin;

            int CantidadCargados = 0;
            int CantidadErrores = 0;

            if (tipCarga == "1")
            {
                var proceso = _db.FiltroReporte.FromSql($"sp_Captura_Cargas_Vez {fechaInicio},{fechaFin},{UsuarioSession}").ToList();
                var reporte = proceso.Select(p => p.ID_CARGA).ToList();

                var listaCargados = _db.TMT_REQUERIMIENTO_GENERAL.Where(x => x.FECHA_FIN_CARGA.Year == fechaFin.Year
                    && x.FECHA_FIN_CARGA.Month == fechaFin.Month
                    && x.FECHA_FIN_CARGA.Day == fechaFin.Day).Where(y => y.FECHA_INICIO_CARGA >= FechaInicio && y.USUARIO_CARGA == UsuarioSession).Where(z => z.PASA_FASE == null)
                    .Where(z => reporte.Contains(z.ID_CARGA))
                    .ToList();

                CantidadCargados = listaCargados.Count();


                var list = _db.TEMPORAL_REPORTE_ERRORES_ENGAGE.Where(x => x.FECHA_FIN_CARGA.Year == fechaFin.Year
                    && x.FECHA_FIN_CARGA.Month == fechaFin.Month
                    && x.FECHA_FIN_CARGA.Day == fechaFin.Day).Where(y => y.FECHA_INICIO_CARGA >= FechaInicio && y.USUARIO_CARGA == UsuarioSession)
                    .Where(z => reporte.Contains(z.ID_CARGA))
                    .ToList();

                CantidadErrores = list.Count();
            }
            else if (tipCarga == "2") {

                var proceso = _db.FiltroReporte.FromSql($"sp_Captura_Cargas_Vez {fechaInicio},{fechaFin},{UsuarioSession}").ToList();
                var reporte = proceso.Select(p => p.ID_CARGA).ToList();

                var listaCargados = _db.TEMPORAL_RECLASIFICACIONES_GENERAL.Where(x => Convert.ToDateTime(x.FECHA_FIN_CARGA).Year == fechaFin.Year
                   && Convert.ToDateTime(x.FECHA_FIN_CARGA).Month == fechaFin.Month
                   && Convert.ToDateTime(x.FECHA_FIN_CARGA).Day == fechaFin.Day).Where(y => Convert.ToDateTime(y.FECHA_INICIO_CARGA) >= FechaInicio && y.USUARIO_CARGA == UsuarioSession).Where(z => z.PASA_FASE == null)
                   .Where(z => reporte.Contains(z.ID_CARGA))
                   .ToList();

                CantidadCargados = listaCargados.Count();


                var list = _db.TEMPORAL_REPORTE_ERRORES_RECLASIFICACIONES.Where(x => Convert.ToDateTime(x.FECHA_FIN_CARGA).Year == fechaFin.Year
                    && Convert.ToDateTime(x.FECHA_FIN_CARGA).Month == fechaFin.Month
                    && Convert.ToDateTime(x.FECHA_FIN_CARGA).Day == fechaFin.Day).Where(y => Convert.ToDateTime(y.FECHA_INICIO_CARGA) >= FechaInicio && y.USUARIO_CARGA == UsuarioSession)
                    .Where(z => reporte.Contains(z.ID_CARGA))
                    .ToList();

                CantidadErrores = list.Count();

            }
            else if (tipCarga == "3") {

                var proceso = _db.FiltroReporte.FromSql($"sp_Captura_Cargas_Vez {fechaInicio},{fechaFin},{UsuarioSession}").ToList();
                var reporte = proceso.Select(p => p.ID_CARGA).ToList();

                var listaCargados = _db.TEMPORAL_ENCUESTAS_GENERAL.Where(x => Convert.ToDateTime(x.FECHA_FIN_CARGA).Year == fechaFin.Year
                    && Convert.ToDateTime(x.FECHA_FIN_CARGA).Month == fechaFin.Month
                    && Convert.ToDateTime(x.FECHA_FIN_CARGA).Day == fechaFin.Day).Where(y => Convert.ToDateTime(y.FECHA_INICIO_CARGA) >= FechaInicio && y.USUARIO_CARGA == UsuarioSession).Where(z => z.PASA_FASE == "")
                    .Where(z => reporte.Contains(z.ID_CARGA))
                    .ToList();

                CantidadCargados = listaCargados.Count();


                var list = _db.TEMPORAL_REPORTE_ERRORES_ENGAGE_ENCUESTAS_USUARIO.Where(x => Convert.ToDateTime(x.FECHA_FIN_CARGA).Year == fechaFin.Year
                    && Convert.ToDateTime(x.FECHA_FIN_CARGA).Month == fechaFin.Month
                    && Convert.ToDateTime(x.FECHA_FIN_CARGA).Day == fechaFin.Day).Where(y => Convert.ToDateTime(y.FECHA_INICIO_CARGA) >= FechaInicio && y.USUARIO_CARGA == UsuarioSession)
                    .Where(z => reporte.Contains(z.ID_CARGA))
                    .ToList();

                CantidadErrores = list.Count();
            }

            ReporteErroresResponse reporteResponse = new ReporteErroresResponse { NumeroCargados = CantidadCargados, NumeroNoProcesados = CantidadErrores };

            return reporteResponse;

        }

        [HttpGet("exportv2")]
        public async Task<IActionResult> ExportV2(CancellationToken cancellationToken,DateTime fechaInicio, DateTime fechaFin,string tipCarga)
        {
            //Se agrego el parametro tipExp que deduce el tipo de exportacion que se dará
            // query data from database  
            await Task.Yield();

            var UsuarioSession = HttpContext.Session.GetString("Usuario");

            var FechaInicio = fechaInicio;
            var FechaFin = fechaFin;

            string excelName = "";

            var stream = new MemoryStream();

            if (tipCarga.ToString() == "1")
            {

                //Necesito obtener los id de cargas para filtrar los reportes.
                var proceso = _db.FiltroReporte.FromSql($"sp_Captura_Cargas_Vez {fechaInicio},{fechaFin},{UsuarioSession}").ToList();
                var reporte = proceso.Select(p => p.ID_CARGA).ToList();


                //Listado de Los Errores
                var list = _db.TEMPORAL_REPORTE_ERRORES_ENGAGE.Where(x => x.FECHA_FIN_CARGA.Year == fechaFin.Year
                                && x.FECHA_FIN_CARGA.Month == fechaFin.Month
                                && x.FECHA_FIN_CARGA.Day == fechaFin.Day).Where(y => y.FECHA_INICIO_CARGA >= FechaInicio && y.USUARIO_CARGA == UsuarioSession
                                ).Where(z => reporte.Contains(z.ID_CARGA)).ToList();

                

                

                

                var listF = from lista in list
                            select new TEMPORAL_REPORTE_ERRORES_ENGAGE_USUARIO
                            {
                                ID_ERROR = lista.ID_ERROR,
                                TICKET = lista.TICKET,
                                ESTADO = lista.ESTADO,
                                SUBESTADO = lista.SUBESTADO,
                                ID_RESOLUTOR = lista.ID_RESOLUTOR,
                                ACCION = lista.ACCION,
                                FECHA_ACCION = lista.FECHA_ACCION,
                                RESOLUTOR_AJUSTE = lista.RESOLUTOR_AJUSTE,
                                FECHA_AJUSTE = lista.FECHA_AJUSTE,
                                TIPO_AJUSTE = lista.TIPO_AJUSTE,
                                MONEDA = lista.MONEDA,
                                CAPITAL = lista.CAPITAL,
                                INTERESES = lista.INTERESES,
                                TOTAL = lista.TOTAL,
                                CENTRO_COSTOS = lista.CENTRO_COSTOS,
                                RESULTADO = lista.RESULTADO,
                                MOTIVO_RESULTADO = lista.MOTIVO_RESULTADO,
                                PRIMERA_FECHA_PASE_PROCEDE = lista.PRIMERA_FECHA_PASE_PROCEDE,
                                PRIMERA_FECHA_PASE_EN_COMUNICACION = lista.PRIMERA_FECHA_PASE_EN_COMUNICACION,
                                PRIMERA_FECHA_PASE_NOTIFICADO = lista.PRIMERA_FECHA_PASE_NOTIFICADO,
                                FECHA_BITACORA = lista.FECHA_BITACORA,
                                AGENTE_BITACORA = lista.AGENTE_BITACORA,
                                COMENTARIO_BITACORA = lista.COMENTARIO_BITACORA,
                                CARTAS_ENVIADAS = lista.CARTAS_ENVIADAS,
                                FECHA_CARTA_ENVIADA = lista.FECHA_CARTA_ENVIADA,
                                AGENTE_CARTA_ENVIADA = lista.AGENTE_CARTA_ENVIADA,
                                FECHA_ENTREGA_CARGO = lista.FECHA_ENTREGA_CARGO,
                                RECIBIDO_POR = lista.RECIBIDO_POR,
                                DNI = lista.DNI,
                                RELACION_TITULAR = lista.RELACION_TITULAR,
                                OBSERVACIONES = lista.OBSERVACIONES,
                                VALIDA_RANGO_ENT_NOT = lista.VALIDA_RANGO_ENT_NOT,
                                VALIDA_RANGO_NOT_SOL = lista.VALIDA_RANGO_NOT_SOL,
                                VALIDA_RANGO_ALL_ENTREGA = lista.VALIDA_RANGO_ALL_ENTREGA,
                                PASA_FASE = lista.PASA_FASE

                            };

                using (var package = new ExcelPackage(stream))
                {
                    var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                    workSheet.Cells.LoadFromCollection(listF, true);
                    package.Save();
                }
                stream.Position = 0;
                excelName = $"Log_Cierre_Masivo_{DateTime.Now.ToString("ddMMyyyy")}.xlsx";

            }
            else if (tipCarga.ToString() == "2") {

                var proceso = _db.FiltroReporte.FromSql($"sp_Captura_Cargas_Vez {fechaInicio},{fechaFin},{UsuarioSession}").ToList();
                var reporte = proceso.Select(p => p.ID_CARGA).ToList();


                //Listado de Los Errores
                var list = _db.TEMPORAL_REPORTE_ERRORES_RECLASIFICACIONES.Where(x => Convert.ToDateTime(x.FECHA_FIN_CARGA).Year == fechaFin.Year
                                && Convert.ToDateTime(x.FECHA_FIN_CARGA).Month == fechaFin.Month
                                && Convert.ToDateTime(x.FECHA_FIN_CARGA).Day == fechaFin.Day).Where(y => Convert.ToDateTime(y.FECHA_INICIO_CARGA) >= FechaInicio && y.USUARIO_CARGA == UsuarioSession)
                                .Where(z => reporte.Contains(z.ID_CARGA)).ToList();
                                


                var listF = from lista in list
                            select new
                            {
                                NUMERO_DE_REGISTRO = lista.ID_ERROR,
                                NUMERO_TICKET = lista.NUM_TICKET,
                                NUEVO_TIPO=lista.NUEVO_TIPO,
                                NUEVO_PRODUCTO=lista.NUEVO_PRODUCTO,
                                NUEVO_SUBPRODUCTO=lista.NUEVO_SUBPRODUCTO,
                                NUEVO_MOTIVO=lista.NUEVO_MOTIVO,
                                NUEVO_SUBMOTIVO=lista.NUEVO_SUBMOTIVO,
                                NUEVO_CODIGO_SBS_SP=lista.NUEVO_CODIGO_SBS_SP,
                                NUEVO_CODIGO_SBS_SM= lista.NUEVO_CODIGO_SBS_SM,
                                NUEVO_CANAL_INGRESO=lista.NUEVO_CANAL_INGRESO,
                                NUEVA_TIENDA=lista.NUEVA_TIENDA,
                                NUEVA_FECHA_SOLICITUD=lista.NUEVA_FECHA_SOLICITUD
                            };



                using (var package = new ExcelPackage(stream))
                {
                    var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                    workSheet.Cells.LoadFromCollection(listF, true);
                    package.Save();
                }
                stream.Position = 0;
                excelName = $"Log_Reclasificaciones_{DateTime.Now.ToString("ddMMyyyy")}.xlsx";

            
            //return File(stream, "application/octet-stream", excelName);  
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);

            }
            else if (tipCarga.ToString() == "3")
            {

                var proceso = _db.FiltroReporte.FromSql($"sp_Captura_Cargas_Vez {fechaInicio},{fechaFin},{UsuarioSession}").ToList();
                var reporte = proceso.Select(p => p.ID_CARGA).ToList();


                //Listado de Los Errores
                var list = _db.TEMPORAL_REPORTE_ERRORES_ENGAGE_ENCUESTAS_USUARIO.Where(x => Convert.ToDateTime(x.FECHA_FIN_CARGA).Year == fechaFin.Year
                                && Convert.ToDateTime(x.FECHA_FIN_CARGA).Month == fechaFin.Month
                                && Convert.ToDateTime(x.FECHA_FIN_CARGA).Day == fechaFin.Day).Where(y => Convert.ToDateTime(y.FECHA_INICIO_CARGA) >= FechaInicio && y.USUARIO_CARGA == UsuarioSession)
                                .Where(z => reporte.Contains(z.ID_CARGA)).ToList();
                                


                var listF = from lista in list
                            select new
                            {
                                NUMERO_DE_REGISTRO = lista.ID_ERROR,
                                NUMERO_TICKET = lista.NUM_TICKET,
                                MAIL = lista.CORREO,
                                FECHA_SOLICITUD = lista.FEC_SOLICITUD,
                                TIPO_ENCUESTA = lista.TIP_ENCUESTA
                            };


                using (var package = new ExcelPackage(stream))
                {
                    var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                    workSheet.Cells.LoadFromCollection(listF, true);
                    package.Save();
                }
                stream.Position = 0;
                excelName = $"Log_Carga_Encuesta__{DateTime.Now.ToString("ddMMyyyy")}.xlsx";

            }
            //return File(stream, "application/octet-stream", excelName);  
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
  
    }
}