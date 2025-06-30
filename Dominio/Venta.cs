using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public int VentaID { get; set; }
        public OrdenesEnvio OrdenesEnvio { get; set; }
        public FacturaPago Factura { get; set; }
    }
}
