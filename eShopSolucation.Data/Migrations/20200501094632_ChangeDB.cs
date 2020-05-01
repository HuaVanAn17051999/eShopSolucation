using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolucation.Data.Migrations
{
    public partial class ChangeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("65653d6d-a1a6-44c6-aa99-eccd2a90bbbd"),
                column: "ConcurrencyStamp",
                value: "9c06ce38-bafb-4c93-b17e-a64c53d1fea1");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("e8fb9b73-3a09-4eb8-a8c2-79fe14b70cd7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c1aa5715-de06-41f6-a8a3-cb724602b2ad", "AQAAAAEAACcQAAAAEHQU3cfOV678G/ApV2oFbdNkIdm2UKgXE0TO56Ln/koUbihLx2sp6H57GHIfLevQgg==" });

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 5, 1, 16, 46, 31, 806, DateTimeKind.Local).AddTicks(7080));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("65653d6d-a1a6-44c6-aa99-eccd2a90bbbd"),
                column: "ConcurrencyStamp",
                value: "a6ab88df-b6bb-4e63-bf42-fb1201aa104e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("e8fb9b73-3a09-4eb8-a8c2-79fe14b70cd7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "facd6e67-8ccc-4d27-a02c-bc5bc77e4f4f", "AQAAAAEAACcQAAAAEA05MXKMN418zwqS9b2v4VFHM8kl5pz86xo4pZGpCa4lqf8MOf4/aJfnBP7ZrZB3TQ==" });

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 4, 30, 14, 29, 31, 292, DateTimeKind.Local).AddTicks(6598));
        }
    }
}
