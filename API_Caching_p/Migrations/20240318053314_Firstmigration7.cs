using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Caching_p.Migrations
{
    /// <inheritdoc />
    public partial class Firstmigration7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "StudentMaster",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "MarkMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SId = table.Column<int>(type: "int", nullable: false),
                    Sub1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarkMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarkMaster_StudentMaster_SId",
                        column: x => x.SId,
                        principalTable: "StudentMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarkMaster_SId",
                table: "MarkMaster",
                column: "SId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarkMaster");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "StudentMaster");
        }
    }
}
