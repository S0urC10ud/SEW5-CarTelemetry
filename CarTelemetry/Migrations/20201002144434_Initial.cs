using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarTelemetry.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    IdCar = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Typ = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.IdCar);
                });

            migrationBuilder.CreateTable(
                name: "TelemetryData",
                columns: table => new
                {
                    IdTelemetryData = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    Speed = table.Column<float>(nullable: false),
                    Capacity = table.Column<float>(nullable: false),
                    CarIdCar = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelemetryData", x => x.IdTelemetryData);
                    table.ForeignKey(
                        name: "FK_TelemetryData_Car_CarIdCar",
                        column: x => x.CarIdCar,
                        principalTable: "Car",
                        principalColumn: "IdCar",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TelemetryData_CarIdCar",
                table: "TelemetryData",
                column: "CarIdCar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelemetryData");

            migrationBuilder.DropTable(
                name: "Car");
        }
    }
}
