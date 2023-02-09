using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class migx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "provizyon_desc",
                table: "GeneralInfo",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "provizyon_desc",
                table: "GeneralInfo");
        }
    }
}
