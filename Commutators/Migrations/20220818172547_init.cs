using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Commutators.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VLANController",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VLANController", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseCommutator",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MAC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VLANControllerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerialNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    InstallDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseCommutator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseCommutator_VLANController_VLANControllerId",
                        column: x => x.VLANControllerId,
                        principalTable: "VLANController",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseCommutator_VLANControllerId",
                table: "BaseCommutator",
                column: "VLANControllerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseCommutator");

            migrationBuilder.DropTable(
                name: "VLANController");
        }
    }
}
