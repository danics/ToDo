using ToDoProjeto.Views.Shared.Enums;

namespace ToDoProjeto.Models
{
    public class Tarefa
    {
        public int Id{get;set;}
        public string Descricao{get;set;}
        public Status Status{get;set;}
    }
}