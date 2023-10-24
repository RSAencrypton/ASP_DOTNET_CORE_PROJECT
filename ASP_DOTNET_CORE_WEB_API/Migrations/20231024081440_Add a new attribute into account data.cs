using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_DOTNET_CORE_WEB_API.Migrations
{
    /// <inheritdoc />
    public partial class Addanewattributeintoaccountdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerDatas",
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
                    table.PrimaryKey("PK_PlayerDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalDataID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerDataID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountDatas_PersonalDatas_PersonalDataID",
                        column: x => x.PersonalDataID,
                        principalTable: "PersonalDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountDatas_PlayerDatas_PlayerDataID",
                        column: x => x.PlayerDataID,
                        principalTable: "PlayerDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountDatas_PersonalDataID",
                table: "AccountDatas",
                column: "PersonalDataID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDatas_PlayerDataID",
                table: "AccountDatas",
                column: "PlayerDataID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountDatas");

            migrationBuilder.DropTable(
                name: "PersonalDatas");

            migrationBuilder.DropTable(
                name: "PlayerDatas");
        }
    }
}
