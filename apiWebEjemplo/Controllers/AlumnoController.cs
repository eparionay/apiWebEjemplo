using apiWebEjemplo.Models;
using apiWebEjemplo.services;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apiWebEjemplo.Controllers
{
    public class AlumnoController : ApiController
    {

        private static readonly ILog LOG = log4net.LogManager.
            GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        [Route("api/info")]
        [HttpGet]
        public String info()
        {
            return "Bienvenido al Curso de DSWI";
        }

        [Route("api/alumno/lista")]
        [HttpGet]
        public List<Alumno> lista(){
           
            ServiceAlumno servicioAlumno = new ServiceAlumno();
            List<Alumno> lista = servicioAlumno.listadoAlumno("listar", 1);
            LOG.Info("Tamano de la Lista : " + lista.Count);
            return lista;
        }

        // api alumno ingresarDatos
        [Route("api/alumno/registrar")]
        [HttpPost]
        public ResponseServer registrar(Alumno alumno)
        {
            ResponseServer rptaServidor = new ResponseServer();
            ServiceAlumno servicioAlumno = new ServiceAlumno();
            int procesar = servicioAlumno.operacionAlumno("registrar", alumno);
            if (procesar<1){
                rptaServidor.mensaje = "Hubo un error.";
                rptaServidor.codigo = 0;
            }
            else
            {
                rptaServidor.mensaje = "Se ingreso correctamente";
                rptaServidor.codigo = 1;
            }
            return rptaServidor;
        }








    }
}
