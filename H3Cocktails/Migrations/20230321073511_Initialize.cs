using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace H3Cocktails.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Ingrediens",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    DrinkName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediens", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Ingrediens_Drinks_DrinkName",
                        column: x => x.DrinkName,
                        principalTable: "Drinks",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediens_DrinkName",
                table: "Ingrediens",
                column: "DrinkName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingrediens");

            migrationBuilder.DropTable(
                name: "Drinks");
        }
    }
}
