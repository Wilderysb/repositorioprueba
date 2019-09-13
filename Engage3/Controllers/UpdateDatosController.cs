using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Engage3.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Engage3.Controllers
{
    public class UpdateDatosController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public bool ValidaSesion;
        private readonly ISession session;
        private readonly TmtGeneralContext _db;


        public UpdateDatosController(IHostingEnvironment env, TmtGeneralContext db, IHttpContextAccessor httpContextAccessor) {

            _db = db;
            _hostingEnvironment = env;
            session = httpContextAccessor.HttpContext.Session;
        }

        // GET: UpdateDatos
        [HttpGet]
        public ActionResult Index(string usuario, string unidad, string sesionId)
        {
            var hola = "";
            var word = false;
            var search = _db.TMT_USRAUT_ENG.Where(x => x.usuario == usuario).Where(y => y.unidad == unidad).Select(z => z.usuario).FirstOrDefault();

            if (search != null)
            {
                word = true;
            }
            var guid = new Guid();

            

            var User = usuario;
            var Unidad = unidad;
            var SesionId = sesionId;


            //ValidaSesion = true;

            if (word == false)
            {
                return Redirect("~/error.html");
            }

            HttpContext.Session.SetString("Usuario", usuario);

            if (usuario != null) { ViewBag.Usuario = User.ToString().Substring(0, 2).ToUpper(); }

            return View();
        }

        [HttpGet]
        public List<ENG_PARAMETRO_DET> CargaEstado()
        {  

            var estado = _db.ENG_PARAMETRO_DET.Where(p => p.COD_PARAM_CAB == 5).ToList();

            return estado;
        }

        [HttpGet]
        public List<ENG_PARAMETRO_DET> CargaSubEstado()
        {
            var estado = _db.ENG_PARAMETRO_DET.Where(p => p.COD_PARAM_CAB == 6).ToList();

            return estado;
        }
        [HttpGet]
        public async Task<BUSQUEDA_RESPUESTA> BuscarRQ (CancellationToken cancellationToken,string ticket)
        {
            await Task.Yield();

            var lista = _db.BUSQUEDA_RESPUESTA.FromSql($"sp_BuscarRQ {ticket}").ToList().FirstOrDefault();
         
            BUSQUEDA_RESPUESTA busquedaRespuesta = new BUSQUEDA_RESPUESTA { CONDICION = lista.CONDICION, ESTADO = lista.ESTADO,SUBESTADO=lista.SUBESTADO };

            return busquedaRespuesta;
        }

        [HttpGet]
        public async Task<BUSQUEDA_CLIENTE> BuscarCliente(CancellationToken cancellationToken, string tipoDoc,string numeroDocumento)
        {
            await Task.Yield();

            var lista = _db.BUSQUEDA_CLIENTE.FromSql($"sp_BuscarCliente {tipoDoc},{numeroDocumento}").ToList().FirstOrDefault();

            BUSQUEDA_CLIENTE busquedaCliente = new BUSQUEDA_CLIENTE { CONDICION = lista.CONDICION, APPATERNO = lista.APPATERNO,
                APMATERNO=lista.APMATERNO, NOMBRES=lista.NOMBRES,DIRECCION=lista.DIRECCION };

            return busquedaCliente;
        }

        [HttpGet]
        public async Task<BUSQUEDA_RESPUESTA> ActualizarRQ(CancellationToken cancellationToken, string ticket,string estado , string subestado)
        {
            await Task.Yield();

            var UsuarioSession = HttpContext.Session.GetString("Usuario");

            var lista = _db.BUSQUEDA_RESPUESTA.FromSql($"sp_ActualizarRQ {ticket},{estado},{subestado},{UsuarioSession}").ToList().FirstOrDefault();

            BUSQUEDA_RESPUESTA busquedaRespuesta = new BUSQUEDA_RESPUESTA { CONDICION = lista.CONDICION, ESTADO = lista.ESTADO, SUBESTADO = lista.SUBESTADO };

            return busquedaRespuesta;
        }

        [HttpGet]
        public async Task<BUSQUEDA_CLIENTE> ActualizarCliente(CancellationToken cancellationToken, string tipoDocumento, string documento, string appaterno, string appmaterno, string nombres, string direccion)
        {
            await Task.Yield();

            var UsuarioSession = HttpContext.Session.GetString("Usuario");

            var lista = _db.BUSQUEDA_CLIENTE.FromSql($"sp_ActualizarCliente {tipoDocumento},{documento}, {appaterno},{appmaterno},{nombres},{direccion},{UsuarioSession}").ToList().FirstOrDefault();

            BUSQUEDA_CLIENTE busquedaCliente = new BUSQUEDA_CLIENTE { CONDICION = lista.CONDICION,APPATERNO=lista.APPATERNO,APMATERNO=lista.APMATERNO,NOMBRES=lista.NOMBRES,DIRECCION=lista.DIRECCION };

            return busquedaCliente;
        }


        // GET: UpdateDatos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UpdateDatos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UpdateDatos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UpdateDatos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UpdateDatos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UpdateDatos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UpdateDatos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}