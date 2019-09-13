using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Engage3.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.IO;
using OfficeOpenXml;
using Microsoft.EntityFrameworkCore;

namespace Engage3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public bool ValidaSesion;
        private readonly ISession session;
        


        private readonly TmtGeneralContext _db;

        public HomeController(IHostingEnvironment env, TmtGeneralContext db,IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _hostingEnvironment = env;
            session= httpContextAccessor.HttpContext.Session;
        }
        [HttpGet]
        public IActionResult Index(string usuario, string unidad, string sesionId)
        {
            var hola = "";
            var word = false;
            var search =_db.TMT_USRAUT_ENG.Where(x => x.usuario == usuario).Where(y=>y.unidad==unidad).Select(z => z.usuario).FirstOrDefault();

            if (search != null)
            {
                word = true;                
            }
            var guid = new Guid();

            

            var User = usuario;
            var Unidad = unidad;
            var SesionId = sesionId;

            //ValidaSesion = true;

            if (word==false)
            {
                return Redirect("~/error.html");
            }

            HttpContext.Session.SetString("Usuario", usuario);
            

            if (usuario != null) { ViewBag.Usuario = User.ToString().Substring(0, 2).ToUpper();}            

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
