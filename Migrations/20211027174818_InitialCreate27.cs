using Microsoft.EntityFrameworkCore.Migrations;

namespace MemGen.Migrations
{
    public partial class InitialCreate27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Nick = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Estatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioID", "Estatus", "Nick", "Nombre", "Password" },
                values: new object[] { 1, 1, "alexMac", "Alejandro", "534b44a19bf18d20b71ecc4eb77c572f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
