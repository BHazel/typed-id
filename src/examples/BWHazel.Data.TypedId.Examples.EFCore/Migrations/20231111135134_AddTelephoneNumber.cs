using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BWHazel.Data.TypedId.Examples.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddTelephoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TelephoneNumberId",
                table: "People",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TelephoneNumbers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelephoneNumbers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelephoneNumbers");

            migrationBuilder.DropColumn(
                name: "TelephoneNumberId",
                table: "People");
        }
    }
}
