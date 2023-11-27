using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OBA.User.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mhitd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonalNumerb",
                table: "UserProfiles");

            migrationBuilder.AddColumn<string>(
                name: "PersonalNumber",
                table: "UserProfiles",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonalNumber",
                table: "UserProfiles");

            migrationBuilder.AddColumn<int>(
                name: "PersonalNumerb",
                table: "UserProfiles",
                type: "int",
                maxLength: 11,
                nullable: false,
                defaultValue: 0);
        }
    }
}
