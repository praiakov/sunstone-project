using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SunstoneProject.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gemstones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", nullable: false),
                    Carat = table.Column<decimal>(type: "decimal", nullable: false),
                    Clarity = table.Column<decimal>(type: "decimal", nullable: false),
                    Color = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gemstones", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gemstones");
        }
    }
}
