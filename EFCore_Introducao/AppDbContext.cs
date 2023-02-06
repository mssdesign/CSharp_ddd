using EFCore_Introducao.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Introducao
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=EFCore;Trusted_Connection=True");
        }
    }
}
