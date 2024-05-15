using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NDATTibbiCihaz.Entity.Migrations
{
    /// <inheritdoc />
    public partial class Gorsel_CiktiIdEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gorseller_Ciktilar_CiktiId",
                table: "Gorseller");

            migrationBuilder.AlterColumn<int>(
                name: "CiktiId",
                table: "Gorseller",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gorseller_Ciktilar_CiktiId",
                table: "Gorseller",
                column: "CiktiId",
                principalTable: "Ciktilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gorseller_Ciktilar_CiktiId",
                table: "Gorseller");

            migrationBuilder.AlterColumn<int>(
                name: "CiktiId",
                table: "Gorseller",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Gorseller_Ciktilar_CiktiId",
                table: "Gorseller",
                column: "CiktiId",
                principalTable: "Ciktilar",
                principalColumn: "Id");
        }
    }
}
