using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_DOTNET_CORE_WEB_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personalDatas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personalDatas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "playerDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Exp = table.Column<int>(type: "int", nullable: false),
                    Money = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playerDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "accountDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalDataID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerDataIDs = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerDatasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accountDatas_personalDatas_PersonalDataID",
                        column: x => x.PersonalDataID,
                        principalTable: "personalDatas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_accountDatas_playerDatas_PlayerDatasId",
                        column: x => x.PlayerDatasId,
                        principalTable: "playerDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accountDatas_PersonalDataID",
                table: "accountDatas",
                column: "PersonalDataID");

            migrationBuilder.CreateIndex(
                name: "IX_accountDatas_PlayerDatasId",
                table: "accountDatas",
                column: "PlayerDatasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accountDatas");

            migrationBuilder.DropTable(
                name: "personalDatas");

            migrationBuilder.DropTable(
                name: "playerDatas");
        }
    }
}
