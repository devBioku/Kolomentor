using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kolomentor.Migrations
{
    /// <inheritdoc />
    public partial class pseudoMentorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pseudoMentorId",
                table: "SkillTypeTopics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pseudoMentorId",
                table: "SkillTypeTopics");
        }
    }
}
