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

        public Cliente cliente { get; set; }

        public Destinatario destinatario { get; set; }

        public int idTransportistaAsignado { get; set; }

        public Ruta ruta { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaEnvio {  get; set; } //cuando se asigne a un transportista

        public DateTime FechaEstimadaLlegada {  get; set; } //REPETITIVO v

        public DateTime FechaDeLlegada { get; set; }

        public EstadoOrdenEnvio estado { get; set; }

        public bool Activo { get; set; }

        //public int CantidadTotalEnviada {  get; set; } //SE REPITE EN DETALLE


    }
}
