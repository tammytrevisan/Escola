using Escola.Models;
using Microsoft.EntityFrameworkCore;

namespace Escola.Context
{
    public class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions<EscolaContext> options)
            : base(options)
        {
        }

        // definir comunicação com as tabelas do banco
        public DbSet<turma> turma { get; set; }
        public DbSet<aluno> aluno { get; set; }

        //sobrescrevendo - configurando API
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
           
             * // relacionando as tabelas
             modelBuilder.Entity<aluno>().ToTable("aluno");
             modelBuilder.Entity<aluno>().HasOne(e => e.Turma)
                 .WithMany(e => e.Alunos)
                 .HasForeignKey(e => e.turmaId);

             modelBuilder.Entity<turma>().ToTable("turma");
             modelBuilder.Entity<turma>().HasOne(e => e.turma)
                 .WithMany(e =>e.aluno)
                 .HasForeignKey(e => e.turmaId);

        }*/

    }

}
