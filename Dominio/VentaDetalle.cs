using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class VentaDetalle
    {
        public int IdVenta { get; set; }
        public EstadoOrdenEnvio EstadoEnvio { get; set; }
        public EstadoDePago  estadoDePago { get; set;}
        public Paquete paquete { get; set; }

        // Cliente
       
        public Usuario usuario { get; set; }
        public Cliente cliente { get; set; }

        // Forma de pago
        public FormaDePago MetodoPago { get; set; }

        //Forma de entrega

        public Destinatario destinatario { get; set; }

        // Totales
        public DetalleOrden detalle { get; set; }
        public float Subtotal { get; set; }
        public float CostoEnvio { get; set; }
        public float Total { get; set; }
    }

}
