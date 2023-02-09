using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class migsc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Maps",
                table: "GeneralInfo",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Maps",
                table: "GeneralInfo");
        }
    }
}
