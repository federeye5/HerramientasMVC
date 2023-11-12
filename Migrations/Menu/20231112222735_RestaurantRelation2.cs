using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clase4.Migrations.Menu
{
    /// <inheritdoc />
    public partial class RestaurantRelation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_restaurants_Menu_MenuId",
                table: "restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_restaurants",
                table: "restaurants");

            migrationBuilder.RenameTable(
                name: "restaurants",
                newName: "Restaurant");

            migrationBuilder.RenameIndex(
                name: "IX_restaurants_MenuId",
                table: "Restaurant",
                newName: "IX_Restaurant_MenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurant",
                table: "Restaurant",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Menu_MenuId",
                table: "Restaurant",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Menu_MenuId",
                table: "Restaurant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurant",
                table: "Restaurant");

            migrationBuilder.RenameTable(
                name: "Restaurant",
                newName: "restaurants");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurant_MenuId",
                table: "restaurants",
                newName: "IX_restaurants_MenuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_restaurants",
                table: "restaurants",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_restaurants_Menu_MenuId",
                table: "restaurants",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
