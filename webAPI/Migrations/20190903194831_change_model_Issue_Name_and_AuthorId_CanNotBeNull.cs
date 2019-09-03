using Microsoft.EntityFrameworkCore.Migrations;

namespace webAPI.Migrations
{
    public partial class change_model_Issue_Name_and_AuthorId_CanNotBeNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Issues",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Issues",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Issues",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Issues",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
