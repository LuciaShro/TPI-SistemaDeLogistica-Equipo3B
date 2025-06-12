using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Destinatario
    {
        public int CUIL { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public Direccion Direccion { get; set; }
        public Usuario Usuario { get; set; }
        public string InfoAdicional { get; set; }
    }
}
