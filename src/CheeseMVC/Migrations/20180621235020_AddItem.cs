using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CheeseMVC.Migrations
{
    public partial class AddItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Cheeses",
                newName: "CategoryID");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true),
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CheseseMenus",
                columns: table => new
                {
                    MenuID = table.Column<int>(nullable: false),
                    CheeseID = table.Column<int>(nullable: false),
                    CheeseMenuCheeseID = table.Column<int>(nullable: true),
                    CheeseMenuMenuID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheseseMenus", x => new { x.CheeseID, x.MenuID });
                    table.ForeignKey(
                        name: "FK_CheseseMenus_Cheeses_CheeseID",
                        column: x => x.CheeseID,
                        principalTable: "Cheeses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheseseMenus_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheseseMenus_CheseseMenus_CheeseMenuCheeseID_CheeseMenuMenuID",
                        columns: x => new { x.CheeseMenuCheeseID, x.CheeseMenuMenuID },
                        principalTable: "CheseseMenus",
                        principalColumns: new[] { "CheeseID", "MenuID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cheeses_CategoryID",
                table: "Cheeses",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CheseseMenus_MenuID",
                table: "CheseseMenus",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_CheseseMenus_CheeseMenuCheeseID_CheeseMenuMenuID",
                table: "CheseseMenus",
                columns: new[] { "CheeseMenuCheeseID", "CheeseMenuMenuID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cheeses_Categories_CategoryID",
                table: "Cheeses",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cheeses_Categories_CategoryID",
                table: "Cheeses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CheseseMenus");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Cheeses_CategoryID",
                table: "Cheeses");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Cheeses",
                newName: "Type");
        }
    }
}
