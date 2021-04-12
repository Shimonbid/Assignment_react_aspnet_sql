using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserQueriesId",
                table: "Results",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Results_UserQueriesId",
                table: "Results",
                column: "UserQueriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_UserQueries_UserQueriesId",
                table: "Results",
                column: "UserQueriesId",
                principalTable: "UserQueries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_UserQueries_UserQueriesId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_UserQueriesId",
                table: "Results");

            migrationBuilder.AlterColumn<int>(
                name: "UserQueriesId",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
