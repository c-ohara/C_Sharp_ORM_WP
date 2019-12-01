using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingPlanner.Migrations
{
    public partial class updatedwedding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Weddings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RSVP",
                columns: table => new
                {
                    RSVPId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WeddingId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RSVP", x => x.RSVPId);
                    table.ForeignKey(
                        name: "FK_RSVP_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RSVP_Weddings_WeddingId",
                        column: x => x.WeddingId,
                        principalTable: "Weddings",
                        principalColumn: "WeddingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_UserId",
                table: "Weddings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RSVP_UserId",
                table: "RSVP",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RSVP_WeddingId",
                table: "RSVP",
                column: "WeddingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Users_UserId",
                table: "Weddings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Users_UserId",
                table: "Weddings");

            migrationBuilder.DropTable(
                name: "RSVP");

            migrationBuilder.DropIndex(
                name: "IX_Weddings_UserId",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Weddings");
        }
    }
}
