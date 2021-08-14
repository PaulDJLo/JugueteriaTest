using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ProductContext : DbContext
    {
        public DbSet<Producto> Productos { set; get; }
       
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(b =>
            {
                b.HasData(new { Id = 1, Nombre = "Barbie Developer", RestriccionEdad = 12, Precio = 25.99, Compania = "Mattel" });

            });
        }
    }
}
