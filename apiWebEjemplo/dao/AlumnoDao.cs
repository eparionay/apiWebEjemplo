using apiWebEjemplo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiWebEjemplo.dao
{
    public interface AlumnoDao
    {
        // Insertar Eliminar Actualizar
        int operacionAlumno(string indicador, Alumno objAlumno);

        // ListarTodosAlumnos, ObtenerAlumnoxI
        List<Alumno> listadoAlumno(string indicador, int codigo);

    }
}