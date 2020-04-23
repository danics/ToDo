using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoProjeto.Data.Migrations
{
    public partial class SeedBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ListaDeTarefas",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Importante" });

            migrationBuilder.InsertData(
                table: "ListaDeTarefas",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Tarefas" });

            migrationBuilder.InsertData(
                table: "ListaDeTarefas",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 4, "Planejado" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ListaDeTarefas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ListaDeTarefas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ListaDeTarefas",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
