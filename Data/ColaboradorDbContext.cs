using System.ComponentModel.DataAnnotations.Schema;
using backendCSharp.Entity;
using Microsoft.EntityFrameworkCore;

namespace backendCSharp.Data
{
	public class ColaboradorDbContext : DbContext
    {
        public ColaboradorDbContext(DbContextOptions<ColaboradorDbContext> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colaborador>()
                .HasKey(c => c.Id)
                .HasAnnotation("DatabaseGeneratedOption", DatabaseGeneratedOption.Identity); // Identity indicates auto-increment
        }

        public DbSet<Colaborador> Colaborador { get; set; }

    }
}

