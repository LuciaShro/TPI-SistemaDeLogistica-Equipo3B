using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int DNI { get; set; }

        public bool Activo { get; set; }

        public Direccion Direccion { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }
    }
}
