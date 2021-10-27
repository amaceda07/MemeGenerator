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
    [ApiController]
    public class MemGenController : ControllerBase
    {
        private readonly Connection Connection;

        public MemGenController(Connection connection)
        {
            Connection = connection;
        }

        #region POST
        [HttpPost]
        public ActionResult<Imagen> Generate(int imagenID, string leyenda)
        {
            try
            {
                if (imagenID == 0) { return BadRequest(); }

                string kk = new MemeGenerator(Connection).Resultado(imagenID, leyenda);
                Imagen imagen = new Imagen()
                {
                    Nombre = $"Meme Generado {DateTime.Now}",
                    URL = kk,
                    Peso = Imagen.GetPeso(kk),
                };
                return imagen;
            }
            catch (Exception)
            {
            }
            return default;
        }
        #endregion

    }
}
