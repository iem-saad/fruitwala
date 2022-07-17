using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fruitwala.Data.Migrations
{
    public partial class Reviewss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sent",
                table: "Review",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Review",
                newName: "FruitReview");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FruitReview",
                table: "Review",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Review",
                newName: "Sent");
        }
    }
}
