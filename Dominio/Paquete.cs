using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Paquete
    {
        public int idPaquete {  get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Stock { get; set; }

        public float Peso { get; set; }

        public float Ancho { get; set; }

        public float Alto {  get; set; }

        public float Largo { get; set; }

        public Categoria NombreCategoria {  get; set; }

    }
}
