using System;
using System.Collections.Generic;
using System.Text;

namespace proyectogallegos.Models
{
    public class Sitio
    {
        public int idSitio { get; set; }
        public string nombreSitio { get; set; }
        public string localidad { get; set; }
        public string ciudad { get; set; }
        public string altitud { get; set; }
        public string foto { get; set; }
        public string longitudx { get; set; }
        public string longitudy { get; set; }
        public string estadoSitio { get; set; }
    }
}
