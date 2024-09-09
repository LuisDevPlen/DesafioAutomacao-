using Microsoft.EntityFrameworkCore;
using ProjetoAecTeste.Models; 
using apiTestes.Data.Map;      

namespace ProjetoAecTeste.Data
{
    public class AluraSearchDbContext : DbContext
    {
        public AluraSearchDbContext(DbContextOptions<AluraSearchDbContext> options)
            : base(options)
        {
        }


        public DbSet<CursoModel> Curso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica a configuração do mapeamento
            modelBuilder.ApplyConfiguration(new CursoItemMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
