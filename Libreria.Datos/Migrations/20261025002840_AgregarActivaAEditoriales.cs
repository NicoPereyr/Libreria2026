using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria.Datos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarActivaAEditoriales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activa",
                table: "Editoriales",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activa",
                table: "Editoriales");
        }
    }
}
