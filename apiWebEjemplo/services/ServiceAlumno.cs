using apiWebEjemplo.dao;
using apiWebEjemplo.dao.daoImpl;
using apiWebEjemplo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiWebEjemplo.services
{
    public class ServiceAlumno
    {
        public int operacionAlumno(string indicador, Alumno objAlumno)
        {
            AlumnoDao dao = new AlumnoDaoImpl();
            return dao.operacionAlumno(indicador, objAlumno);
        }

        public List<Alumno> listadoAlumno(string indicador, int codigo)
        {
            AlumnoDao dao = new AlumnoDaoImpl();
            return dao.listadoAlumno(indicador, codigo);
        }
    }
}