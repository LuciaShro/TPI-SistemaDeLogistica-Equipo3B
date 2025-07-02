using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class FacturaPago
    {
        public int idFactura { get; set; }
        public int NumeroFactura { get; set; }

        public OrdenesEnvio OrdenesEnvio { get; set; }

        //public DetalleOrden idDetalle {  get; set; }

        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public long cuilEmisor { get; set; }
        public string razonSocial { get; set; }
        public FormaDePago formaDePago { get; set; }

        //public string MetodoPago { get; set; }

        //public Ruta idruta { get; set; }

        public decimal Total { get; set; }
    }
}
