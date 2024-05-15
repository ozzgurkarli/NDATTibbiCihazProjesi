using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NDATTibbiCihaz.Entity.Migrations
{
    /// <inheritdoc />
    public partial class MakineCalisiyorKaldirildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calisiyor",
                table: "Makineler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Calisiyor",
                table: "Makineler",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
