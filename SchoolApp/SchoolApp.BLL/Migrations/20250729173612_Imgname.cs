using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.BLL.Migrations
{
    /// <inheritdoc />
    public partial class Imgname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "STUDIMG",
                table: "Students",
                newName: "ImgName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgName",
                table: "Students",
                newName: "STUDIMG");
        }
    }
}
