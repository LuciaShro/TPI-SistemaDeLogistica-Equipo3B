using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Ruta
    {
        public string PuntoPartida {  get; set; }

        public string PuntoDestino { get; set; }

        public float DistanciaEnKM { get; set; }

        public int TiempoEstimadoMinutos { get; set; }
    }
}
