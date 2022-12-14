using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpemProject.Migrations
{
    public partial class migration_00005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CoOfferedWithId",
                table: "Courses",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CoOfferedWithId",
                table: "Courses",
                column: "CoOfferedWithId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Courses_CoOfferedWithId",
                table: "Courses",
                column: "CoOfferedWithId",
                principalTable: "Courses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Courses_CoOfferedWithId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CoOfferedWithId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CoOfferedWithId",
                table: "Courses");
        }
    }
}
