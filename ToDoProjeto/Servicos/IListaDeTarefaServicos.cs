using System.Threading.Tasks;
using ToDoProjeto.Models;
using ToDoProjeto.ViewModels;

namespace ToDoProjeto.Servicos
{
    public interface IListaDeTarefaServicos
    {
        Task<ListaDeTarefa> Add(ListaDeTarefaViewModel listaDeTarefaViewModel);
        Task<bool> Delete(int Id);
    }
}