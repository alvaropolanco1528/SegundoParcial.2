using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segundoparcial._2.Models;
using Microsoft.EntityFrameworkCore;

namespace Segundoparcial._2.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Telefonos> telefonos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Database/Data.db");
        }
    }
}
