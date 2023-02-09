using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class migss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fifteen_price",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "monthy_price",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "yearly_price",
                table: "Cars",
                newName: "daily_price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "daily_price",
                table: "Cars",
                newName: "yearly_price");

            migrationBuilder.AddColumn<double>(
                name: "fifteen_price",
                table: "Cars",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "monthy_price",
                table: "Cars",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
