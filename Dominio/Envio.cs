using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Envio
    {
        public int Codigo { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public string NombreEstado { get; set; }
        public string ColorEstado { get; set; }
        public string DetalleEstado { get; set; }
    }
}
