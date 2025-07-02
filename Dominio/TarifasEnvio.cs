using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TarifasEnvio
    {
        public int Id { get; set; }
        public Categoria Categoria { get; set; }
        public decimal PrecioPorKm { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }
    }
}
