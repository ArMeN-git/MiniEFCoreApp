using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniEFCoreApp.Migrations
{
    public partial class AgentClients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgentClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentUserId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentClients_AgentUserId_ClientId",
                table: "AgentClients",
                columns: new[] { "AgentUserId", "ClientId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AgentClients_ClientId",
                table: "AgentClients",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentClients");
        }
    }
}
