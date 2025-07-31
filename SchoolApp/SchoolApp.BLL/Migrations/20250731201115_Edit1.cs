using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.BLL.Migrations
{
    /// <inheritdoc />
    public partial class Edit1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_Mobile1",
                table: "Students",
                column: "Mobile1",
                unique: true,
                filter: "[Mobile1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Students_NATID",
                table: "Students",
                column: "NATID",
                unique: true,
                filter: "[NATID] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_Mobile1",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_NATID",
                table: "Students");
        }
    }
}
