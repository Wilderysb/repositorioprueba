using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Engage3.Models
{
    public class TmtGeneralContext :DbContext
    {
        public TmtGeneralContext (DbContextOptions<TmtGeneralContext> options)
            : base(options)
        {
        }

        public DbSet<Engage3.Models.TMT_REQUERIMIENTO_GENERAL> TMT_REQUERIMIENTO_GENERAL { get; set; }
        public DbSet<Engage3.Models.TMT_USRAUT_ENG> TMT_USRAUT_ENG { get; set; }
        public virtual DbSet<Prueba> Prueba { get; set; }
        public virtual DbSet<BUSQUEDA_RESPUESTA> BUSQUEDA_RESPUESTA { get; set; }
        public virtual DbSet<BUSQUEDA_CLIENTE> BUSQUEDA_CLIENTE { get; set; }
        public virtual DbSet<FiltroReporte> FiltroReporte { get; set; }
        public virtual DbSet<TEMPORAL_REPORTE_ERRORES_ENGAGE> TEMPORAL_REPORTE_ERRORES_ENGAGE { get; set; }
        public virtual DbSet<TEMPORAL_REPORTE_ERRORES_ENGAGE_USUARIO> TEMPORAL_REPORTE_ERRORES_ENGAGE_USUARIO { get; set; }
        public virtual DbSet<TEMPORAL_ENCUESTAS_GENERAL> TEMPORAL_ENCUESTAS_GENERAL { get; set; }
        public virtual DbSet<TEMPORAL_REPORTE_ERRORES_ENGAGE_ENCUESTAS_USUARIO> TEMPORAL_REPORTE_ERRORES_ENGAGE_ENCUESTAS_USUARIO { get; set; }
        public virtual DbSet<TMT_CONTROL_CARGAS> TMT_CONTROL_CARGAS { get; set; }
        public virtual DbSet<TEMPORAL_RECLASIFICACIONES_GENERAL> TEMPORAL_RECLASIFICACIONES_GENERAL { get; set; }
        public virtual DbSet<TEMPORAL_REPORTE_ERRORES_RECLASIFICACIONES> TEMPORAL_REPORTE_ERRORES_RECLASIFICACIONES { get; set; }
        public virtual DbSet<ENG_PARAMETRO_DET> ENG_PARAMETRO_DET { get; set; }



    }
}
