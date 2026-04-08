using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ZCPWebServices.Migrations
{
    public partial class InitialDatabaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ejecutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaCierre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idZcp = table.Column<int>(type: "int", nullable: false),
                    municipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroTicketCcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroTicketProveedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paradaReloj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    resumenCierre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subcategoria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
