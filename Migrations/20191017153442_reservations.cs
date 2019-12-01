using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingPlanner.Migrations
{
    public partial class reservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RSVP_Users_UserId",
                table: "RSVP");

            migrationBuilder.DropForeignKey(
                name: "FK_RSVP_Weddings_WeddingId",
                table: "RSVP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RSVP",
                table: "RSVP");

            migrationBuilder.RenameTable(
                name: "RSVP",
                newName: "Reservations");

            migrationBuilder.RenameIndex(
                name: "IX_RSVP_WeddingId",
                table: "Reservations",
                newName: "IX_Reservations_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_RSVP_UserId",
                table: "Reservations",
                newName: "IX_Reservations_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "RSVPId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Weddings_WeddingId",
                table: "Reservations",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Weddings_WeddingId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "RSVP");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_WeddingId",
                table: "RSVP",
                newName: "IX_RSVP_WeddingId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_UserId",
                table: "RSVP",
                newName: "IX_RSVP_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RSVP",
                table: "RSVP",
                column: "RSVPId");

            migrationBuilder.AddForeignKey(
                name: "FK_RSVP_Users_UserId",
                table: "RSVP",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RSVP_Weddings_WeddingId",
                table: "RSVP",
                column: "WeddingId",
                principalTable: "Weddings",
                principalColumn: "WeddingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
