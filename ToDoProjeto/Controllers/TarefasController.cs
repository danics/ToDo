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

        public async Task<IActionResult> Edit(int Id)
        {
            ViewData["ListaTitulo"] = _context.ListaDeTarefas.Where(x => x.Id == Id).FirstOrDefault();
            var tarefas = await _context.Tarefas.Where(x => x.ListaDeTarefaId == Id).ToListAsync();
            var tarefasViewModel = new List<TarefaViewModel>();
            foreach(var tarefa in tarefas)
            {
                tarefasViewModel.Add(new TarefaViewModel{
                    Id = tarefa.Id,
                    Descricao = tarefa.Descricao,                                    
                });

            }
            return View(tarefasViewModel);
        } 

    }
}