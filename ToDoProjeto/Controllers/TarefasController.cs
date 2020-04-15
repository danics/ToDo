using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoProjeto.Data;
using ToDoProjeto.Models;
using ToDoProjeto.ViewModels.Tarefas;

namespace ToDoProjeto.Controllers
{
    [Authorize]        
    public class TarefasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TarefasController(ApplicationDbContext context)
        {
            _context = context;
        }   
        public ActionResult Index()
        {    
            ViewData["ListasDeTarefa"] = _context.ListaDeTarefas.ToList();        
            return View();
        }  

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["ListaTitulo"] = _context.ListaDeTarefas.Where(x => x.Id == id).FirstOrDefault();
            var tarefas = await _context.Tarefas.Where(x => x.ListaDeTarefaId == id).ToListAsync();
            var tarefasViewModel = new List<TarefaViewModel>();
            foreach(var tarefa in tarefas)
            {
                tarefasViewModel.Add(new TarefaViewModel{
                    Id = tarefa.Id,
                    Descricao = tarefa.Descricao,                                    
                });

            }           
            ViewData["ListasDeTarefa"] = _context.ListaDeTarefas.ToList();
            return View(tarefasViewModel);            
        } 

    }
}