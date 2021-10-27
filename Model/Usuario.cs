using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemGen.Model
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public int Estatus { get; set; }


        List<Usuario> Usuarios { get; set; } = new List<Usuario>();

        bool ValidaAcceso(string password) => password == Password;

    }
}
