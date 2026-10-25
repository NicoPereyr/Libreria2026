using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria.Datos.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablasLibros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    LibroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AnioPublicacion = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    EditorialId = table.Column<int>(type: "int", nullable: false),
                    TipoLibro = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    IdentificadorDigital = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Formato = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TamanioMB = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    UrlDescarga = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.LibroId);
                    table.ForeignKey(
                        name: "FK_Libros_Editoriales_EditorialId",
                        column: x => x.EditorialId,
                        principalTable: "Editoriales",
                        principalColumn: "EditorialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LibrosAutores",
                columns: table => new
                {
                    AutoresAutorId = table.Column<int>(type: "int", nullable: false),
                    LibroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibrosAutores", x => new { x.AutoresAutorId, x.LibroId });
                    table.ForeignKey(
                        name: "FK_LibrosAutores_Autores_AutoresAutorId",
                        column: x => x.AutoresAutorId,
                        principalTable: "Autores",
                        principalColumn: "AutorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibrosAutores_Libros_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libros",
                        principalColumn: "LibroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibrosTemas",
                columns: table => new
                {
                    LibroId = table.Column<int>(type: "int", nullable: false),
                    TemasTemaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibrosTemas", x => new { x.LibroId, x.TemasTemaId });
                    table.ForeignKey(
                        name: "FK_LibrosTemas_Libros_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libros",
                        principalColumn: "LibroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibrosTemas_Temas_TemasTemaId",
                        column: x => x.TemasTemaId,
                        principalTable: "Temas",
                        principalColumn: "TemaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_EditorialId",
                table: "Libros",
                column: "EditorialId");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_IdentificadorDigital",
                table: "Libros",
                column: "IdentificadorDigital",
                unique: true,
                filter: "[IdentificadorDigital] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_ISBN",
                table: "Libros",
                column: "ISBN",
                unique: true,
                filter: "[ISBN] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LibrosAutores_LibroId",
                table: "LibrosAutores",
                column: "LibroId");

            migrationBuilder.CreateIndex(
                name: "IX_LibrosTemas_TemasTemaId",
                table: "LibrosTemas",
                column: "TemasTemaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibrosAutores");

            migrationBuilder.DropTable(
                name: "LibrosTemas");

            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}
