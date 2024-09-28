using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTodoFieldName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                schema: "todoService",
                table: "Todos",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                schema: "todoService",
                table: "Todos",
                newName: "Text");
        }
    }
}
