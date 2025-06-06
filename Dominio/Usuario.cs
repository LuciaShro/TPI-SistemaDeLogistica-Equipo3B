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
        public enum TipoUsuario {
            cliente = 1,
            empleado = 2,
            admin= 3,

        }
        public int idUsuario {  get; set; }

        public string User { get; set; }

        public string Password {  get; set; }

        public string Email {  get; set; }

        public TipoUsuario tipoUsuario {  get; set; }

        public Usuario (string username, string password, TipoUsuario tipousuario)
        {

            User = username;
            Password = password;
            tipoUsuario = tipousuario;
        }
    }
}
