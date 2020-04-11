using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoProjeto.Data.Migrations
{
    public partial class AddForeignkeydaListadeTarefanaEntidadeTarefa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_ListaDeTarefas_ListaDeTarefaId",
                table: "Tarefas");

            migrationBuilder.AlterColumn<int>(
                name: "ListaDeTarefaId",
                table: "Tarefas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_ListaDeTarefas_ListaDeTarefaId",
                table: "Tarefas",
                column: "ListaDeTarefaId",
                principalTable: "ListaDeTarefas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_ListaDeTarefas_ListaDeTarefaId",
                table: "Tarefas");

            migrationBuilder.AlterColumn<int>(
                name: "ListaDeTarefaId",
                table: "Tarefas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_ListaDeTarefas_ListaDeTarefaId",
                table: "Tarefas",
                column: "ListaDeTarefaId",
                principalTable: "ListaDeTarefas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
