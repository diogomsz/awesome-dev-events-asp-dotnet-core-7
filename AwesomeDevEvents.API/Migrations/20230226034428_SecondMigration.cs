using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomeDevEvents.API.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TalkTime",
                table: "DevEventsSpeakers",
                newName: "TalkTitle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TalkTitle",
                table: "DevEventsSpeakers",
                newName: "TalkTime");
        }
    }
}
