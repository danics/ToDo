using System.Threading.Tasks;
using ToDoProjeto.Models;
using ToDoProjeto.Repositorios;
using ToDoProjeto.ViewModels;

namespace ToDoProjeto.Servicos
{
    public class ListaDeTarefaServicos : IListaDeTarefaServicos
    {
        private readonly IListasDeTarefasRepositorio _listaDeTarefaRepositorio;

        public ListaDeTarefaServicos(IListasDeTarefasRepositorio listaDeTarefaRepositorio)
        {
            _listaDeTarefaRepositorio = listaDeTarefaRepositorio;
        }

        public async Task<ListaDeTarefa> Add(ListaDeTarefaViewModel listaDeTarefaViewModel)
        {
            var listaDeTarefa = new ListaDeTarefa()
            {
                Id = listaDeTarefaViewModel.Id,
                Nome = listaDeTarefaViewModel.Nome,   
                UsuarioId = listaDeTarefaViewModel.UsuarioId             
            };  

            var listaDeTarefaBd = await _listaDeTarefaRepositorio.Add(listaDeTarefa);
            return listaDeTarefaBd;
        }

        public Task<bool> Delete(int Id)
        {
            var retorno = _listaDeTarefaRepositorio.Delete(Id);
            return retorno;
        }
    } 
}