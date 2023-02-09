using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class migcsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "aboutOffice",
                table: "GeneralInfo",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "aboutOffice",
                table: "GeneralInfo");
        }
    }
}
