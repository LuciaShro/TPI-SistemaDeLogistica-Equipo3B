using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class FormaDePago
    {
        public int idFormaDePago {  get; set; }
        public string medioDePago { get; set; } //Transferencia, MP
        public DateTime fechaDePago { get; set; }
        public EstadoDePago estadoDePago { get; set; }
        public Cliente Cliente { get; set; }
    }
}
