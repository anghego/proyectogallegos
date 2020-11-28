using System;
using System.Collections.Generic;
using System.Text;

namespace proyectogallegos.Models
{
    public class Expedicion
    {
        public int idExpedicion { get; set; }
        public string actividad { get; set; }
        public DateTime fecha { get; set; }
        public string duracion { get; set; }
        public string edadMinima { get; set; }
        public float costo { get; set; }
        public string nivel { get; set; }
        public string estadoExpedicion { get; set; }
    }
}
