using MemGen.Data;
using MemGen.Interface;
using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace MemGen.Model
{
    public class MemeGenerator : IMemGen
    {
        Connection Connection;


        public MemeGenerator(Connection connection)
        {
            Connection = connection;
        }

        public string Resultado(int imagenID, string texto)
        {
            string resultado = string.Empty;
            if (string.IsNullOrEmpty(texto)){ return "[ERR] No hay texto para ingresar"; }
            // busco la imagen en la DB
            Imagen img = Connection.Imagenes.Find(imagenID);
            if (img == null) { return "[ERR] No se encontró la imagen solicitada"; }
            try
            {
                resultado = Escribe(img, texto);
            }
            catch (Exception ex)
            {
                resultado = $"[ERR] Ocurrió un error / {ex.Message}";
            }
            return resultado;
        }

        private string Escribe(Imagen imagen, string texto)
        {
            try
            {
                string resultado = "";
                string txtFinal = texto.Replace(" ", "");
                string imgFinal = $"{imagen.Nombre}_{txtFinal}.png";
                string directorio = (string)AppDomain.CurrentDomain.GetData("ContentRootPath") + "\\Resultados\\"; 

                WebClient client = new WebClient();
                Stream stream = client.OpenRead(imagen.URL);
                Bitmap bitmap = new Bitmap(stream);

                if (bitmap != null)
                {

                    // bitmap = (Bitmap)Image.FromFile(Path.Combine(directorio, imgFinal));

                    PointF position = new PointF(bitmap.Width / 5, bitmap.Height / 6);

                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        using (Font arialFont = new Font("Arial", 45))
                        {
                            graphics.DrawString(texto, arialFont, Brushes.White, position);
                        }
                    }
                    // guardamos la imagem
                    // bitmap.Save(Path.Combine(directorio, imgFinal, bitmap.GetType().ToString()));
                    var kkDir = Path.GetFullPath(@"\Resultados\") + imgFinal;
                    bitmap.Save(kkDir);
                    resultado = imgFinal;
                }
                else
                {
                    resultado = "[ERR] No se encuentra la imagen para descargar";
                }

                stream.Flush();
                stream.Close();
                client.Dispose();

                return resultado;
            }
            catch (Exception ex)
            {

                return $"[ERR] Ocurrió un error al momento de traer la información / {ex.Message}";
            }
        }
    }
}
