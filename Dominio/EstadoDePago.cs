using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class EstadoDePago
    {
        public int idEstadoDePago { get; set; }

        public String nombreEstado { get; set; } //Rechazado, Pendiente, Recibido
    }
}
