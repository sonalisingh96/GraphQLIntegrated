using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Isbn = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Author = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Isbn);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Isbn", "Author", "Title" },
                values: new object[] { "ISBN 978-9930943106", "J. K. Rowling", "Harry Porter" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Isbn", "Author", "Title" },
                values: new object[] { "ISBN 978-9929801646", "Enid Blyton", "Famous Five" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
