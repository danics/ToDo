using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoProjeto.Models;

namespace ToDoProjeto.Repositorios
{
    public interface ITarefasRepositorio
    {
        List<Tarefa> GetByListaDeTarefaId(int id);
        Task<Tarefa> Add(Tarefa tarefa);
        Tarefa GetById(int Id);
        Tarefa Delete(int Id);
        Task<bool> ChangeStatus(Tarefa tarefa);
    }
}