using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpyCheif.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Assets");

            migrationBuilder.AddColumn<Guid>(
                name: "AssetTypeId",
                table: "Assets",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "AssetType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetType", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ServiceDatabases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DatabaseName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CollentionName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDatabases", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetTypeId",
                table: "Assets",
                column: "AssetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_AssetType_AssetTypeId",
                table: "Assets",
                column: "AssetTypeId",
                principalTable: "AssetType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AssetType_AssetTypeId",
                table: "Assets");

            migrationBuilder.DropTable(
                name: "AssetType");

            migrationBuilder.DropTable(
                name: "ServiceDatabases");

            migrationBuilder.DropIndex(
                name: "IX_Assets_AssetTypeId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "AssetTypeId",
                table: "Assets");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Assets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
