using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Magazyn3.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Towary",
                columns: table => new
                {
                    IdTowaru = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Cena = table.Column<decimal>(nullable: false),
                    Magazyn = table.Column<int>(nullable: false),
                    NazwaTowaru = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towary", x => x.IdTowaru);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Towary");
        }
    }
}
