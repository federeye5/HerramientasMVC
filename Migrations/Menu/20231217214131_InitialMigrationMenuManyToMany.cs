using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clase4.Migrations.Menu
{
    /// <inheritdoc />
    public partial class InitialMigrationMenuManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    IsVegetarian = table.Column<bool>(type: "INTEGER", nullable: false),
                    Calories = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Adress = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<int>(type: "INTEGER", nullable: false),
                    MenuId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MenuRestaurant",
                columns: table => new
                {
                    Menusid = table.Column<int>(type: "INTEGER", nullable: false),
                    Restaurantsid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuRestaurant", x => new { x.Menusid, x.Restaurantsid });
                    table.ForeignKey(
                        name: "FK_MenuRestaurant_Menu_Menusid",
                        column: x => x.Menusid,
                        principalTable: "Menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuRestaurant_Restaurant_Restaurantsid",
                        column: x => x.Restaurantsid,
                        principalTable: "Restaurant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuRestaurant_Restaurantsid",
                table: "MenuRestaurant",
                column: "Restaurantsid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuRestaurant");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Restaurant");
        }
    }
}
