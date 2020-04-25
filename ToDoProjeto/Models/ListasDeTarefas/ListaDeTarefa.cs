using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ToDoProjeto.Models
{
    public class ListaDeTarefa
    {
        public int Id{get;set;}
        public string Nome{get;set;}
        public List<Tarefa> TerefasDaLista{get;set;}
        public string UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public IdentityUser Usuario { get; set; }
    }
}