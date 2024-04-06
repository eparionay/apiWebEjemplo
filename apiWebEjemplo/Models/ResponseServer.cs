using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiWebEjemplo.Models
{
    public class ResponseServer
    {
        public int codigo { get; set; }  // 1 Exitoso  // Otro numero Error
        public string mensaje { get; set; } // Mensaje Se ingreso correctamente, o hubo un error
    }
}