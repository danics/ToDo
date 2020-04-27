using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoProjeto.Models;
using ToDoProjeto.Repositorios;
using ToDoProjeto.ViewModels.Tarefas;

namespace ToDoProjeto.Servicos
{
    public class TarefasServico : ITarefasServico
    {
        private readonly ITarefasRepositorio _tarefasRepositorio;

        public TarefasServico(ITarefasRepositorio tarefasRepositorio)
        {
            _tarefasRepositorio = tarefasRepositorio;
        }

        public List<TarefaViewModel> GetByListaDeTarefaId(int id)
        {
            var tarefas = _tarefasRepositorio.GetByListaDeTarefaId(id);
            var tarefasViewModel = new List<TarefaViewModel>();

            foreach(var tarefa in tarefas)
            {
                tarefasViewModel.Add(new TarefaViewModel{
                    Id = tarefa.Id,
                    Descricao = tarefa.Descricao, 
                    Status = tarefa.Status,
                    ListaDeTarefaId = tarefa.ListaDeTarefaId                                   
                });
            }  

            return tarefasViewModel;    
        }

        public async Task<Tarefa> Add(TarefaViewModel tarefaViewModel)
        {
            var tarefa = new Tarefa()
            {
                Id = tarefaViewModel.Id,
                Descricao = tarefaViewModel.Descricao,
                Status = tarefaViewModel.Status,
                ListaDeTarefaId = tarefaViewModel.ListaDeTarefaId
            };

            var tarefaBd = await _tarefasRepositorio.Add(tarefa);   
            return tarefaBd;          
        }

        public Task<bool> ChangeStatus(TarefaViewModel tarefaViewModel)
        {
            var tarefa = new Tarefa()
            {
                Id = tarefaViewModel.Id,
                Descricao = tarefaViewModel.Descricao,
                Status = tarefaViewModel.Status,
                ListaDeTarefaId = tarefaViewModel.ListaDeTarefaId
            };

            var retorno = _tarefasRepositorio.ChangeStatus(tarefa);
            return retorno;   
        }

        public Tarefa Delete(int Id)
        {
            var tarefa = _tarefasRepositorio.Delete(Id);
            return tarefa;
        }
    }
}