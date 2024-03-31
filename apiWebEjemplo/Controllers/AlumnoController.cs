using apiWebEjemplo.Models;
using apiWebEjemplo.services;
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
            return lista;
        }




    }
}
