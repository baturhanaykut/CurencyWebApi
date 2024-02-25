using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrencyWebApi.Infrastructre.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    AtributeName = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrenyDetails",
                columns: table => new
                {
                    CurrenyId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Value = table.Column<string>(type: "VARCHAR(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrenyDetails", x => new { x.CurrenyId, x.Date });
                    table.ForeignKey(
                        name: "FK_CurrenyDetails_Currencies_CurrenyId",
                        column: x => x.CurrenyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrenyDetails");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
