using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoProjeto.Data.Migrations
{
    public partial class AddUsuarioIdnaEntidadeListaDeTarefa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ListaDeTarefas",
                keyColumn: "Id",
                keyValue: 1);

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

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "ListaDeTarefas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListaDeTarefas_UsuarioId",
                table: "ListaDeTarefas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDeTarefas_AspNetUsers_UsuarioId",
                table: "ListaDeTarefas",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListaDeTarefas_AspNetUsers_UsuarioId",
                table: "ListaDeTarefas");

            migrationBuilder.DropIndex(
                name: "IX_ListaDeTarefas_UsuarioId",
                table: "ListaDeTarefas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "ListaDeTarefas");

            migrationBuilder.InsertData(
                table: "ListaDeTarefas",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Meu Dia" },
                    { 2, "Importante" },
                    { 3, "Tarefas" },
                    { 4, "Planejado" }
                });
        }
    }
}
