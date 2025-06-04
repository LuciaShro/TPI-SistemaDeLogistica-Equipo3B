using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int idUsuario {  get; set; }

        public string NombreUsuario { get; set; }

        public string Email {  get; set; }

        public string Clave {  get; set; }

        public string FechaRegistro { get; set; }
    }
}
