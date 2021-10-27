using MemGen.Model;
using Microsoft.EntityFrameworkCore;


namespace MemGen.Data
{
    public class Connection : DbContext
    {

        public DbSet<Imagen> Imagenes { get; set; }

        public Connection(DbContextOptions<Connection> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Imagen>().HasData
          (
          new Imagen { ImagenID = 1, Nombre = "SpongeBob_Walking", URL = "https://plantillasdememes.com/img/plantillas/bob-esponja-entrando-por-la-puerta-al-salon01565047441.jpg" },
          new Imagen { ImagenID = 2, Nombre = "MichaelScott_Lip", URL = "https://newfastuff.com/wp-content/uploads/2020/04/ddum8cj2d6s41.png" },
          new Imagen { ImagenID = 3, Nombre = "Jim_Watching", URL = "https://newfastuff.com/wp-content/uploads/2019/05/ml77Rv1.png" }

          );
        }


    }
}
