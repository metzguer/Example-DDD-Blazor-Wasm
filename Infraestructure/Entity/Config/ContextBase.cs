using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Entity.Config
{
    public class ContextBase : DbContext
    { 
        public ContextBase(DbContextOptions<ContextBase> options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if (!builder.IsConfigured) {
                builder.UseSqlServer(ConectionString);
            } 
        }

        private string ConectionString = "Server=METZGUER\\MSSQLSERVER01;Database=food;Trusted_Connection=true;MultipleActiveResultSets=true;";
    }
}
