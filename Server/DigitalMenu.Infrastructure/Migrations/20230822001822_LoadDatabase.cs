using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DigitalMenu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LoadDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("83d92fe2-cb25-4603-85e7-2910da489694"), "Limão melhor ainda", "Limão" },
                    { new Guid("ed66f47f-15b3-463f-84b9-dc16976a4d2f"), "Banana boa", "Banana" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("83d92fe2-cb25-4603-85e7-2910da489694"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("ed66f47f-15b3-463f-84b9-dc16976a4d2f"));
        }
    }
}
