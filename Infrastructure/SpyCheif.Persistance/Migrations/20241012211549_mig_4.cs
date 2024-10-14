using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpyCheif.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AssetType_Id",
                table: "AssetType",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Id",
                table: "Assets",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AssetType_Id",
                table: "AssetType");

            migrationBuilder.DropIndex(
                name: "IX_Assets_Id",
                table: "Assets");
        }
    }
}
