using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int idProducto {  get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Stock { get; set; }

        public float Peso { get; set; }

        public float Ancho { get; set; }

        public float Alto {  get; set; }

        public float Profundidad { get; set; }

        public Marca NombreMarca { get; set; }

        public Categoria NombreCategoria {  get; set; }

    }
}
