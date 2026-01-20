using Microsoft.EntityFrameworkCore;
using Sistema_de_Controle_de_Gastos_Residenciais.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Sistema_de_Controle_de_Gastos_Residenciais.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                .HasMany(p => p.Transacoes)
                .WithOne(t => t.Pessoa)
                .HasForeignKey(t => t.PessoaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
