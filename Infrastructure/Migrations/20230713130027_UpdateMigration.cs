using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalPoint.Infra.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkPointsHistorics_AspNetUsers_UserId",
                table: "WorkPointsHistorics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkPointsHistorics",
                table: "WorkPointsHistorics");

            migrationBuilder.RenameTable(
                name: "WorkPointsHistorics",
                newName: "WorkPoints");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "WorkPoints",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkPointsHistorics_UserId",
                table: "WorkPoints",
                newName: "IX_WorkPoints_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkPoints",
                table: "WorkPoints",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkPoints_AspNetUsers_ApplicationUserId",
                table: "WorkPoints",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkPoints_AspNetUsers_ApplicationUserId",
                table: "WorkPoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkPoints",
                table: "WorkPoints");

            migrationBuilder.RenameTable(
                name: "WorkPoints",
                newName: "WorkPointsHistorics");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "WorkPointsHistorics",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkPoints_ApplicationUserId",
                table: "WorkPointsHistorics",
                newName: "IX_WorkPointsHistorics_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkPointsHistorics",
                table: "WorkPointsHistorics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkPointsHistorics_AspNetUsers_UserId",
                table: "WorkPointsHistorics",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
