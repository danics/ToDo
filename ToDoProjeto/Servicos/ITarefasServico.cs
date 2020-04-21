using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoProjeto.Models;
using ToDoProjeto.ViewModels.Tarefas;

namespace ToDoProjeto.Servicos
{
    public interface ITarefasServico
    {
        List<TarefaViewModel> GetByListaDeTarefaId(int id);
        Task<Tarefa> Add(TarefaViewModel tarefaViewModel);
        Tarefa Delete(int Id);
    }
}