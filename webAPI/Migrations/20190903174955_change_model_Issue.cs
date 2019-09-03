using Microsoft.EntityFrameworkCore.Migrations;

namespace webAPI.Migrations
{
    public partial class change_model_Issue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Issues",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "Assignee",
                table: "Issues",
                newName: "AssigneeId");

            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "Issues",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Issues",
                newName: "Author");

            migrationBuilder.RenameColumn(
                name: "AssigneeId",
                table: "Issues",
                newName: "Assignee");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Issues",
                nullable: true,
                oldClrType: typeof(byte));
        }
    }
}
