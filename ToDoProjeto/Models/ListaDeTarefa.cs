using System.Collections.Generic;

namespace ToDoProjeto.Models
{
    public class ListaDeTarefa
    {
        public int Id{get;set;}
        public string Nome{get;set;}
        public List<Tarefa> TerefasDaLista{get;set;}
    }
}