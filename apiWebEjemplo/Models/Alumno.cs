using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiWebEjemplo.Models
{
    public class Alumno
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Genero { get; set; }
        public string Documento { get; set; }
        public int Estado { get; set; }

    }
}