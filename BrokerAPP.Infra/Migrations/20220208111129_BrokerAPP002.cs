using Microsoft.EntityFrameworkCore.Migrations;

namespace BrokerAPP.Infra.Migrations
{
    public partial class BrokerAPP002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Clients_ClientId",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_ClientId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Assets");

            migrationBuilder.CreateTable(
                name: "ClientsAssets",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsAssets", x => new { x.AssetId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_ClientsAssets_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientsAssets_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientsAssets_ClientId",
                table: "ClientsAssets",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientsAssets");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Assets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ClientId",
                table: "Assets",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Clients_ClientId",
                table: "Assets",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
