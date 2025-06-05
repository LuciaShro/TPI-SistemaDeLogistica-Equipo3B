using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class OrdenesEnvio
    {
        public int idOrdenEnvio {  get; set; }

        public Persona persona { get; set; }

        public Cliente cliente { get; set; }

        public Transportista transportistaAsignado { get; set; }

        public Ruta ruta { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaEnvio {  get; set; }

        public DateTime FechaEstimadaLlegada {  get; set; }

        public DateTime FechaDeLlegada { get; set; }

        public Estado estado { get; set; }

        public int CantidadTotalEnviada {  get; set; }

        public DetalleOrden detalleOrden {  get; set; }

    }
}
