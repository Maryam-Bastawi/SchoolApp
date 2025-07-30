using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.BLL.Migrations
{
    /// <inheritdoc />
    public partial class CreatePROJ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    CUID = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CUNM = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    CUNM_E = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: true),
                    TYPEID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mobile1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Mobile2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LOCATION = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: true),
                    RESPONS = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: true),
                    CREDIT_LIMIT = table.Column<int>(type: "int", nullable: true),
                    SUSPIND_AC = table.Column<byte>(type: "tinyint", nullable: true),
                    IDNUM = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    IDISSIODATE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IDENDDATE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IDPLACE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NATID = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: true),
                    STUDIMG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VECHID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    STAGESID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    GRADESID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    STUDENTSTATUSID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NEXTGRADE = table.Column<byte>(type: "tinyint", nullable: true),
                    CLASSROOM = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AREAID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SCHOOLID = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    STOPSMS = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    STUDSEX = table.Column<byte>(type: "tinyint", nullable: true),
                    DEPART = table.Column<byte>(type: "tinyint", nullable: true),
                    STUDIDNUM = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    SUSPINDDATE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ISGRADUATE = table.Column<byte>(type: "tinyint", nullable: true),
                    PASSPORT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BIRTHDATE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NOTE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ISNEWYEAR = table.Column<byte>(type: "tinyint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.CUID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_IDNUM",
                table: "Students",
                column: "IDNUM",
                unique: true,
                filter: "[IDNUM] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Students_PASSPORT",
                table: "Students",
                column: "PASSPORT",
                unique: true,
                filter: "[PASSPORT] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
