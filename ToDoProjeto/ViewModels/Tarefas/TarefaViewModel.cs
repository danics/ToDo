using ToDoProjeto.Views.Shared.Enums;

namespace ToDoProjeto.ViewModels.Tarefas
{
    public class TarefaViewModel
    {
        public int Id{get;set;}
        public string Descricao{get;set;}
        public Status Status{get;set;}
        public int ListaDeTarefaId{get;set;}        
    }
}