using MemGen.Data;
using MemGen.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MemGen.Controllers
{
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly Connection Connection;

        public UsuariosController(Connection connection)
        {
            Connection = connection;
        }

        #region HTTPGET
        [HttpGet]
        public ActionResult<List<Usuario>> GetUsuarios()
        {
            return Ok(Connection.Usuarios.ToList());
        }

        #endregion

    }
}
