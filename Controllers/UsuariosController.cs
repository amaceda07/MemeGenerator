using MemGen.Data;
using MemGen.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("{usuarioID}")]
        public ActionResult<Usuario> GetUsuario(int usuarioID)
        {
            var kk = Connection.Usuarios.Find(usuarioID);
            if (kk != null)
            {
                return Ok(kk);
            }
            else
            {
                return NotFound();
            }
        }

        #endregion

        #region HTTPPOST
        [HttpPost]
        public async Task<ActionResult<Usuario>> AddUsuario(Usuario usuario)
        {
            Connection.Usuarios.Add(usuario);
            await Connection.SaveChangesAsync();
            return CreatedAtAction("GetUsuario", new { usuarioID = usuario.UsuarioID }, usuario);
        }
        #endregion

        #region HTTPPUT
        public async Task<ActionResult<IActionResult>> UpdateUser(int usuarioID, Usuario usuario)
        {
            if (usuarioID != usuario.UsuarioID) { return BadRequest(); }
            Connection.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            try
            {
                await Connection.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExisteUsuario(usuarioID)) { return NotFound(); }
                throw;
            }
            return NoContent();
        }
        #endregion

        #region HTTPDELETE
        public async Task<ActionResult<Usuario>> DeleteUser(int usuarioID)
        {
            if (!ExisteUsuario(usuarioID)) { return NotFound(); }
            Connection.Usuarios.Remove(await Connection.Usuarios.FindAsync(usuarioID));
            await Connection.SaveChangesAsync();
            return Ok("[Success]");
        }
        #endregion



        #region Funciones
        private bool ExisteUsuario(int usuarioID)
        {
            return Connection.Usuarios.Any(e => e.UsuarioID == usuarioID);
        }
        #endregion
    }
}
