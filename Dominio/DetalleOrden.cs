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

        /*public int Cantidad { get; set; } */// Aca vendria a ser cantidad de paquetes? se envia un pq x destino o mas de uno?

        public decimal Total { get; set; }

        public OrdenesEnvio Orden {  get; set; }
    }
}
