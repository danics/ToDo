using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoProjeto.Data.Migrations
{
    public partial class AddEntidadeListaDeTarefas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListaDeTarefaId",
                table: "Tarefas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ListaDeTarefas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaDeTarefas", x => x.Id);
                });           

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ListaDeTarefaId",
                table: "Tarefas",
                column: "ListaDeTarefaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_ListaDeTarefas_ListaDeTarefaId",
                table: "Tarefas",
                column: "ListaDeTarefaId",
                principalTable: "ListaDeTarefas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_ListaDeTarefas_ListaDeTarefaId",
                table: "Tarefas");

            migrationBuilder.DropTable(
                name: "ListaDeTarefas");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_ListaDeTarefaId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "ListaDeTarefaId",
                table: "Tarefas");
        }
    }
}
