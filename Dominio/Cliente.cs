using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente: Persona
    {
        public string Telefono {  get; set; }

        public string FechaAlta {  get; set; }

        public Usuario Usuario { get; set; }
    }
}
