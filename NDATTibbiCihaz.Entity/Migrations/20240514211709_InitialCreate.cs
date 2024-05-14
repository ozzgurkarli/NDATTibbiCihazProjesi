using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NDATTibbiCihaz.Entity.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doktorlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktorlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hastalar",
                columns: table => new
                {
                    TCKimlikNo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedeniDurum = table.Column<bool>(type: "bit", nullable: false),
                    DoktorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastalar", x => x.TCKimlikNo);
                });

            migrationBuilder.CreateTable(
                name: "Makineler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KapakDurumu = table.Column<bool>(type: "bit", nullable: false),
                    XRayDurumu = table.Column<bool>(type: "bit", nullable: false),
                    PlatformDonusDurumu = table.Column<bool>(type: "bit", nullable: false),
                    TaramaDurumu = table.Column<bool>(type: "bit", nullable: false),
                    Kullanilabilirlik = table.Column<bool>(type: "bit", nullable: false),
                    Calisiyor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makineler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Raporlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorId = table.Column<int>(type: "int", nullable: false),
                    CiktiId = table.Column<int>(type: "int", nullable: false),
                    RaporTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Yorum = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raporlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ciktilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastaTCKimlikNo = table.Column<long>(type: "bigint", nullable: false),
                    RaporId = table.Column<int>(type: "int", nullable: false),
                    Path3D = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CiktiTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonulenDerece = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciktilar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciktilar_Hastalar_HastaTCKimlikNo",
                        column: x => x.HastaTCKimlikNo,
                        principalTable: "Hastalar",
                        principalColumn: "TCKimlikNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gorseller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PathGorsel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aci = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CiktiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gorseller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gorseller_Ciktilar_CiktiId",
                        column: x => x.CiktiId,
                        principalTable: "Ciktilar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ciktilar_HastaTCKimlikNo",
                table: "Ciktilar",
                column: "HastaTCKimlikNo");

            migrationBuilder.CreateIndex(
                name: "IX_Gorseller_CiktiId",
                table: "Gorseller",
                column: "CiktiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doktorlar");

            migrationBuilder.DropTable(
                name: "Gorseller");

            migrationBuilder.DropTable(
                name: "Makineler");

            migrationBuilder.DropTable(
                name: "Raporlar");

            migrationBuilder.DropTable(
                name: "Ciktilar");

            migrationBuilder.DropTable(
                name: "Hastalar");
        }
    }
}
