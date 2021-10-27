using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MemGen.Model
{
    public class Imagen
    {
        public int ImagenID { get; set; }
        public string Nombre { get; set; }
        public string URL { get; set; }
        public double Peso { get; set; }

        List<Imagen> Imagenes { get; set; } = new List<Imagen>();

        internal static double GetPeso(string uRL)
        {
            try
            {
                using (WebClient cliente = new WebClient())
                {
                    cliente.OpenRead(uRL);
                    double.TryParse(cliente.ResponseHeaders["Content-Length"], out double finalSize);
                    return finalSize;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
