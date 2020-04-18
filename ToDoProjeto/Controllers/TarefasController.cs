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
                    ListaDeTarefaId = tarefa.ListaDeTarefaId                                   
                });

            }           
            ViewData["ListasDeTarefa"] = _context.ListaDeTarefas.ToList();
            return View(tarefasViewModel);            
        } 

        [HttpPost]
        public async Task<IActionResult> Create(TarefaViewModel tarefaViewModel)
        {
            var tarefa = new Tarefa()
            {
                Id = tarefaViewModel.Id,
                Descricao = tarefaViewModel.Descricao,
                Status = tarefaViewModel.Status,
                ListaDeTarefaId = tarefaViewModel.ListaDeTarefaId
            };

            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return Json(tarefa);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var tarefa = _context.Tarefas.Find(Id);
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();

            return RedirectToAction("Edit", new {Id = tarefa.ListaDeTarefaId});
        }
    }
}