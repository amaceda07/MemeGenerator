using MemGen.Data;
using MemGen.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemGen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenesController : ControllerBase
    {

        private readonly Connection Connection;

        public ImagenesController(Connection connection)
        {
            Connection = connection;
        }

        #region GET
        [HttpGet]
        public ActionResult<List<Imagen>> GetAll()
        {
            return Ok(Connection.Imagenes.ToList());
        }

        [HttpGet("{imagenID}")]
        public ActionResult<Imagen> GetImagen(int imagenID)
        {
            var kk = Connection.Imagenes.Find(imagenID);
            if (kk != null)
            {
                kk.Peso = Imagen.GetPeso(kk.URL);
                return Ok(kk);
            }
            else
            {
                return NotFound();
            }

        }
        #endregion


        #region POST
        [HttpPost]
        public async Task<ActionResult<Imagen>> AddImage(Imagen imagen)
        {
            Connection.Imagenes.Add(imagen);
            await Connection.SaveChangesAsync();
            return CreatedAtAction("GetImagen", new { imagenID = imagen.ImagenID }, imagen);
        }
        #endregion

        #region PUT
        [HttpPut]
        public async Task<ActionResult<IActionResult>> UpdateImage(int imagenID, Imagen imagen)
        {
            if (imagenID != imagen.ImagenID) { return BadRequest(); }
            Connection.Entry(imagen).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            try
            {
                await Connection.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExisteImagen(imagenID)){
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }
        #endregion

        #region DELETE
        public async Task<ActionResult<Imagen>> DeleteImage(int imagenID)
        {
            if (!ExisteImagen(imagenID)) { return NotFound(); }
            Connection.Imagenes.Remove(await Connection.Imagenes.FindAsync(imagenID));
            await Connection.SaveChangesAsync();
            return Ok("[Success]");
        }
        #endregion


        #region Funciones
        private bool ExisteImagen(int imagenID)
        {
            return Connection.Imagenes.Any(e => e.ImagenID == imagenID);
        }
        #endregion
    }
}
