using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoProjeto.Data;
using ToDoProjeto.Models;
using ToDoProjeto.ViewModels;

namespace ToDoProjeto.Controllers
{
    public class ListasDeTarefasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListasDeTarefasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ListaDeTarefaViewModel listaDeTarefaViewModel)
        {
            var listaDeTarefa = new ListaDeTarefa()
            {
                Id = listaDeTarefaViewModel.Id,
                Nome = listaDeTarefaViewModel.Nome,                
            };                        
            
            _context.ListaDeTarefas.Add(listaDeTarefa);
            await _context.SaveChangesAsync();
            return Json(listaDeTarefa);
        }   
    }
}