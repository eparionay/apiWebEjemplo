using apiWebEjemplo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiWebEjemplo.dao
{
    public interface AlumnoDao
    {
        int operacionAlumno(string indicador, Alumno objAlumno);

        List<Alumno> listadoAlumno(string indicador, int codigo);

    }
}