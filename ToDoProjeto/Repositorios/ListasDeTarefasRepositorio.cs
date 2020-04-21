using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoProjeto.Data;
using ToDoProjeto.Models;

namespace ToDoProjeto.Repositorios
{
    public class ListasDeTarefasRepositorio : IListasDeTarefasRepositorio
    {
        private readonly ApplicationDbContext _context;

        public ListasDeTarefasRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ListaDeTarefa>> GetAll()
        {
            return await _context.ListaDeTarefas.ToListAsync();             
        }

        public ListaDeTarefa GetById(int id)
        {
            return _context.ListaDeTarefas.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<ListaDeTarefa> Add(ListaDeTarefa listaDeTarefa)
        {
            _context.ListaDeTarefas.Add(listaDeTarefa);
            await _context.SaveChangesAsync();
            return listaDeTarefa;
        }

        public async Task<bool> Delete(int Id)
        {
            var listaTarefa = _context.ListaDeTarefas.Find(Id);

            if(listaTarefa != null)
            {
                _context.ListaDeTarefas.Remove(listaTarefa);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;   
        }
    }
}