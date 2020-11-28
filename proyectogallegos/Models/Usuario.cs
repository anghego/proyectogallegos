using System;
using System.Collections.Generic;
using System.Text;

namespace proyectogallegos.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cedula { get; set; }
        public string telefono { get; set; }
        public string mail { get; set; }
        public string estado { get; set; }
    }
}
