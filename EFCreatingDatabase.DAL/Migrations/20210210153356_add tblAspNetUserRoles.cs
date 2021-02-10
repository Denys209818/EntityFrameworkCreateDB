using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCreatingDatabase.DAL.Migrations
{
    public partial class addtblAspNetUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAspNetUserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_tblAspNetUserRoles_tblAspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tblAspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblAspNetUserRoles_tblAspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "tblAspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAspNetUserRoles_UserId",
                table: "tblAspNetUserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAspNetUserRoles");
        }
    }
}
