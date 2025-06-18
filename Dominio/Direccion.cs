using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Direccion
    {
        public int idDireccion { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Ciudad {  get; set; }

        public string CodigoPostal { get; set; }

        public string Provincia { get; set; }

        public int NumeroCalle {  get; set; }

        public string Piso { get; set; }

    }
}
