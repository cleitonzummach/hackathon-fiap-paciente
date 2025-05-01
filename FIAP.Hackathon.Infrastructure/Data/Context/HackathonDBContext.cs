using FIAP.Hackathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Hackathon.Infrastructure.Data.Context
{
    public class HackathonDBContext : DbContext
    {
        public HackathonDBContext(DbContextOptions<HackathonDBContext> options) : base(options)
        {
        }

        public DbSet<Paciente> Paciente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>()
                .HasKey(m => m.PacienteId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
