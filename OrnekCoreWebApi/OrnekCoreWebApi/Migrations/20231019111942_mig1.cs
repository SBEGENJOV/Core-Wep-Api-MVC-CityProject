using Microsoft.EntityFrameworkCore.Migrations;

namespace OrnekCoreWebApi.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ulkes",
                columns: table => new
                {
                    UlkeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UlkeAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UlkeSehirSay = table.Column<int>(type: "int", nullable: false),
                    UlkeBaskent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulkes", x => x.UlkeID);
                });

            migrationBuilder.CreateTable(
                name: "Sehirs",
                columns: table => new
                {
                    SehirID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SehirIlceSay = table.Column<int>(type: "int", nullable: false),
                    UlkeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehirs", x => x.SehirID);
                    table.ForeignKey(
                        name: "FK_Sehirs_Ulkes_UlkeID",
                        column: x => x.UlkeID,
                        principalTable: "Ulkes",
                        principalColumn: "UlkeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ilces",
                columns: table => new
                {
                    IlceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlceAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IlceBaskan = table.Column<int>(type: "int", nullable: false),
                    SehirID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilces", x => x.IlceID);
                    table.ForeignKey(
                        name: "FK_Ilces_Sehirs_SehirID",
                        column: x => x.SehirID,
                        principalTable: "Sehirs",
                        principalColumn: "SehirID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ilces_SehirID",
                table: "Ilces",
                column: "SehirID");

            migrationBuilder.CreateIndex(
                name: "IX_Sehirs_UlkeID",
                table: "Sehirs",
                column: "UlkeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ilces");

            migrationBuilder.DropTable(
                name: "Sehirs");

            migrationBuilder.DropTable(
                name: "Ulkes");
        }
    }
}
