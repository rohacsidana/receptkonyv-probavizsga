using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace receptek_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kategoriak",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nev = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__kategori__3213E83F6968877E", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "receptek",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nev = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    kat_id = table.Column<int>(type: "int", nullable: true),
                    kep_eleresi_ut = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    leiras = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__receptek__3213E83FB8ED4774", x => x.id);
                    table.ForeignKey(
                        name: "FK__receptek__leiras__29572725",
                        column: x => x.kat_id,
                        principalTable: "kategoriak",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_receptek_kat_id",
                table: "receptek",
                column: "kat_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "receptek");

            migrationBuilder.DropTable(
                name: "kategoriak");
        }
    }
}
