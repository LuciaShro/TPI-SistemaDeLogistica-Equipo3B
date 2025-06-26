using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        public int id;
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public long CUIL { get; set; }

        public bool Activo { get; set; }

        public Direccion Direccion { get; set; }

        public string Telefono { get; set; }

        public Usuario Usuario { get; set; }

        public string InfoAdicional { get; set; }
    }
}
