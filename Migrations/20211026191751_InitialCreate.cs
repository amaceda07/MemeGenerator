using Microsoft.EntityFrameworkCore.Migrations;

namespace MemGen.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Imagenes",
                columns: table => new
                {
                    ImagenID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    URL = table.Column<string>(type: "TEXT", nullable: true),
                    Peso = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagenes", x => x.ImagenID);
                });

            migrationBuilder.InsertData(
                table: "Imagenes",
                columns: new[] { "ImagenID", "Nombre", "Peso", "URL" },
                values: new object[] { 1, "SpongeBob_Walking", 0.0, "https://plantillasdememes.com/img/plantillas/bob-esponja-entrando-por-la-puerta-al-salon01565047441.jpg" });

            migrationBuilder.InsertData(
                table: "Imagenes",
                columns: new[] { "ImagenID", "Nombre", "Peso", "URL" },
                values: new object[] { 2, "MichaelScott_Lip", 0.0, "https://newfastuff.com/wp-content/uploads/2020/04/ddum8cj2d6s41.png" });

            migrationBuilder.InsertData(
                table: "Imagenes",
                columns: new[] { "ImagenID", "Nombre", "Peso", "URL" },
                values: new object[] { 3, "Jim_Watching", 0.0, "https://newfastuff.com/wp-content/uploads/2019/05/ml77Rv1.png" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imagenes");
        }
    }
}
