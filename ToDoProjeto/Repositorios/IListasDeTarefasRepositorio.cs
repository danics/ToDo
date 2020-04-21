using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoProjeto.Models;

namespace ToDoProjeto.Repositorios
{
    public interface IListasDeTarefasRepositorio
    {
        Task<List<ListaDeTarefa>> GetAll();
        ListaDeTarefa GetById(int id);
        Task<ListaDeTarefa> Add(ListaDeTarefa listaDeTarefa);
        Task<bool> Delete(int Id);
    }
}