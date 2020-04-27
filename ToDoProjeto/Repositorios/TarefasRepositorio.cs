using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoProjeto.Data;
using ToDoProjeto.Models;

namespace ToDoProjeto.Repositorios
{
    public class TarefasRepositorio : ITarefasRepositorio
    {
        private readonly ApplicationDbContext _context;

        public TarefasRepositorio(ApplicationDbContext context)
        {
            _context = context;            
        }

        public List<Tarefa> GetByListaDeTarefaId(int id)
        {
            return _context.Tarefas.Where(x => x.ListaDeTarefaId == id).ToList();                        
        }

        public async Task<Tarefa> Add(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync(); 
            return tarefa;           
        }

        public Tarefa GetById(int Id)
        {
            return _context.Tarefas.Find(Id);
        }

        public async Task<bool> ChangeStatus(Tarefa tarefa)
        {            
            if(tarefa != null)
            {
                _context.Tarefas.Update(tarefa);
                await _context.SaveChangesAsync();
                return true;                             
            }
            return false;
        }

        public Tarefa Delete(int Id)
        {
            var tarefa = GetById(Id);
            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();

            return tarefa;
        }
    }
}