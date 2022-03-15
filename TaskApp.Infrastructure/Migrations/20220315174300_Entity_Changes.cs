using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApp.Infrastructure.Migrations
{
    public partial class Entity_Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriesHomeworks",
                table: "CategoriesHomeworks");

            migrationBuilder.DropIndex(
                name: "IX_CategoriesHomeworks_CategoryId",
                table: "CategoriesHomeworks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CategoriesHomeworks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriesHomeworks",
                table: "CategoriesHomeworks",
                columns: new[] { "CategoryId", "HomeworkId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriesHomeworks",
                table: "CategoriesHomeworks");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CategoriesHomeworks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriesHomeworks",
                table: "CategoriesHomeworks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesHomeworks_CategoryId",
                table: "CategoriesHomeworks",
                column: "CategoryId");
        }
    }
}
