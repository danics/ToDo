using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoProjeto.Data;
using ToDoProjeto.Models;
using ToDoProjeto.Repositorios;
using ToDoProjeto.Servicos;
using ToDoProjeto.ViewModels.Tarefas;

namespace ToDoProjeto.Controllers
{
    [Authorize]        
    public class TarefasController : Controller
    {        
        private readonly IListasDeTarefasRepositorio _listasDeTarefasRepositorio;
        private readonly ITarefasServico _tarefasServico;
        private readonly UserManager<IdentityUser> _userManager;

        public TarefasController(IListasDeTarefasRepositorio listasDeTarefasRepositorio, 
                                 ITarefasServico tarefasServico,
                                 UserManager<IdentityUser> userManager)
        {            
            _listasDeTarefasRepositorio = listasDeTarefasRepositorio;
            _tarefasServico = tarefasServico;
            _userManager = userManager;
        }   
        public async Task<IActionResult> Index()
        {    
            ViewData["ListasDeTarefa"] = await _listasDeTarefasRepositorio.GetAll(_userManager.GetUserId(User)); 
            ViewBag.UsuarioId = _userManager.GetUserId(User);    
            return View();
        }          
        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["ListaTitulo"] = _listasDeTarefasRepositorio.GetById(id);    
            var tarefasViewModel = _tarefasServico.GetByListaDeTarefaId(id); 
           
            ViewData["ListasDeTarefa"] = await _listasDeTarefasRepositorio.GetAll(_userManager.GetUserId(User));
            ViewBag.UsuarioId = _userManager.GetUserId(User);
            return View(tarefasViewModel);            
        } 

        [HttpPost]
        public async Task<IActionResult> Create(TarefaViewModel tarefaViewModel)
        {
            var tarefa = await _tarefasServico.Add(tarefaViewModel);            
            return Json(tarefa);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var tarefa = _tarefasServico.Delete(Id);            

            return RedirectToAction("Edit", new {Id = tarefa.ListaDeTarefaId});
        }
    }
}