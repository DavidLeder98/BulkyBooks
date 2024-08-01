using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addProductsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Billy the Hero", "A beginner's guide for aspiring heroes, the Enchiridion is packed with essential advice for new adventurers. Learn the basics of combat, survival, and questing, along with tips for navigating the world of heroes. This book is the perfect starting point for anyone looking to embark on a heroic journey.", "ENC1234567", 900.0, 850.0, 750.0, 800.0, "Enchiridion" },
                    { 2, "Xergoloth the Mad", "Dive into the dark arts with the Morellonomicon, a grimoire filled with forbidden spells and malevolent enchantments. This book is not for the faint-hearted, as it reveals the sinister paths of necromancy and demonology. Perfect for those who dare to harness the power of the shadows.", "MOR7654321", 500.0, 490.0, 400.0, 450.0, "Morellonomicon" },
                    { 3, "Wardun the One-armed", "Designed for novice warriors, this manual provides a thorough introduction to the art of sword fighting. It covers basic techniques, footwork, and defensive maneuvers to build a solid foundation. Master the fundamentals and prepare yourself for any battle with confidence.", "SWD1010101", 50.0, 45.0, 35.0, 40.0, "Swordsmanship for Beginners" },
                    { 4, "Arch Wizard Toadbottom", "An essential handbook for aspiring spellcasters, Basics of Cantrips introduces readers to the simplest and most practical spells. This guide covers a variety of everyday enchantments, perfect for beginners looking to hone their magical skills. Start your journey into the magical arts with ease.", "BOC4445444", 100.0, 90.0, 70.0, 80.0, "Basics of Cantrips" },
                    { 5, "Bob", "Explore the mysterious and dangerous creatures that inhabit the Black Woods with this detailed bestiary. Each entry provides descriptions, habits, and weaknesses of the forest's denizens, from the elusive Shadow Stalker to the fearsome Night Terror. Equip yourself with the knowledge to survive and thrive in the dark wilderness.", "BBW1122448", 30.0, 29.0, 25.0, 27.0, "Bestiary of the Black Woods" },
                    { 6, "Moralla Goodman", "Navigate the moral dilemmas of adventuring with this updated guide on ethical behavior in the field. This edition covers new scenarios and offers advice on maintaining honor and integrity. A crucial resource for any adventurer committed to doing the right thing, even in the face of peril.", "AEE3333333", 15.0, 14.0, 12.0, 13.0, "Adventuring Ethics 3rd Edition" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
