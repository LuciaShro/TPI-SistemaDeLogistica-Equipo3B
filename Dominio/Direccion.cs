using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Direccion
    {
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Piso { get; set; }
        public string Ciudad {  get; set; }

        public int CodigoPostal { get; set; }

        public string Provincia { get; set; }
    }
}
