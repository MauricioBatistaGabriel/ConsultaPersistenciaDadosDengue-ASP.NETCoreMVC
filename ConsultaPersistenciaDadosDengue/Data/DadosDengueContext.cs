using ConsultaPersistenciaDadosDengue.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultaPersistenciaDadosDengue.Data
{
    public class DadosDengueContext : DbContext
    {
        public DadosDengueContext(DbContextOptions<DadosDengueContext> options) : base(options)
        {
        }
        public DbSet<DadosDengueModel> DadosDengue { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DadosDengueModel>().HasKey(d => d.id);
        }
    }
}
