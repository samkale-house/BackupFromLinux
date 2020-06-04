using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieManagement.Migrations
{
    public partial class extend_IdentityUSer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "ID",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2020, 2, 18, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "ID",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(2020, 2, 17, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
