using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetalleOrden
    {
        public Paquete paquete {  get; set; }

        public int Cantidad { get; set; }

        public float Total { get; set; }

        public OrdenesEnvio idOrden {  get; set; }
    }
}
