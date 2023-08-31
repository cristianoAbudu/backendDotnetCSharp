using System;
using backendCSharp.Entity;
using Microsoft.EntityFrameworkCore;

namespace backendCSharp.Data
{
	public class ColaboradorDbContext : DbContext
    {
        public ColaboradorDbContext(DbContextOptions<ColaboradorDbContext> context) : base(context)
        {

        }

        public DbSet<Colaborador> Colaborador { get; set; }
    }
}

