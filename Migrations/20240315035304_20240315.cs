using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManyToManyCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class _20240315 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerIdGuid",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: Guid.NewGuid());;

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "CustomerIdGuid",
                value: Guid.NewGuid());;

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "CustomerIdGuid",
                value: Guid.NewGuid());;

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "CustomerIdGuid",
                value: Guid.NewGuid());;
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerIdGuid",
                table: "Customers");
        }
    }
}
