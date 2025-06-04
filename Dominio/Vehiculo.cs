using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vehiculo
    {
        public int idVehiculo {  get; set; }
        public string Nombre { get; set; }

        public string Patente { get; set; }

        public float CapacidadCarga { get; set; }
    }
}
