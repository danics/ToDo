using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoProjeto.Data;
using ToDoProjeto.Models;
using ToDoProjeto.Servicos;
using ToDoProjeto.ViewModels;

namespace ToDoProjeto.Controllers
{
    public class ListasDeTarefasController : Controller
    {        
        private readonly IListaDeTarefaServicos _listaDeTarefaServicos;

        public ListasDeTarefasController(IListaDeTarefaServicos listaDeTarefaServicos)
        {
            _listaDeTarefaServicos = listaDeTarefaServicos;            
        }

        [HttpPost]
        public async Task<IActionResult> Create(ListaDeTarefaViewModel listaDeTarefaViewModel)
        {
            var listaDeTarefa = await _listaDeTarefaServicos.Add(listaDeTarefaViewModel);            
            return Json(listaDeTarefa);
        } 

        [HttpPost]
        public Task<bool> Delete(int Id)
        {                       
            return _listaDeTarefaServicos.Delete(Id);                      
        }  
    }
}