using System.Collections.Generic;
using ToDoProjeto.Models;

namespace ToDoProjeto.ViewModels
{
    public class ListaDeTarefaViewModel
    {
        public int Id{get;set;}
        public string Nome{get;set;}
        public List<Tarefa> TerefasDaLista{get;set;}
    }
}