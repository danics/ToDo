using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoProjeto.Models;

namespace ToDoProjeto.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas {get;set;}
        public DbSet<ListaDeTarefa> ListaDeTarefas{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
	        modelBuilder.Entity<ListaDeTarefa>().HasData(new ListaDeTarefa{Id = 1, Nome = "Meu Dia"});           
	        base.OnModelCreating(modelBuilder);
        }
    }    
}
