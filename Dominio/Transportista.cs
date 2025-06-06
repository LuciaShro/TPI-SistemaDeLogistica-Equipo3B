using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Transportista
    {
        public string Nombre {  get; set; }

        public string Apellido { get; set; }

        public int Legajo { get; set; }

        public string Telefono { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraFin {  get; set; }

        public string Licencia { get; set; }

        public bool EstadoDisponibilidad { get; set; }

        public bool Activo {  get; set; }

        public Usuario usuario { get; set; }
        public Vehiculo Vehiculo { get; set; }


    }
}
