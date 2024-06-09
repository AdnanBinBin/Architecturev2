
using DAL.DB.Model;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PrintContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<ProductRate> ProductRates { get; set; }
        public DbSet<Transaction> Transactions { get; set; }







        public PrintContext(DbContextOptions<PrintContext> options) : base(options)
        {
        }

   

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ArchitecturePrintUseCaseV5");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(u => u.Budget)
            .WithOne(b => b.User)
            .HasForeignKey<Budget>(b => b.IdUser);

             modelBuilder.Entity<User>()
            .HasOne(u => u.Card)
            .WithOne(c => c.User)
            .HasForeignKey<Card>(c => c.IdUser);

            modelBuilder.Entity<User>()
           .HasMany(u => u.Transactions) // Un utilisateur peut avoir plusieurs trans actions
           .WithOne(t => t.User)         // Chaque transaction appartient à un seul utilisateur
           .HasForeignKey(t => t.IdUser);

            modelBuilder.Entity<User>().HasData(
                new User { IdUser=1,FirstName = "Adnan", LastName = "Binjos", Username = "Binjos.Adnan" },
                new User { IdUser=2,FirstName = "Adriano", LastName = "Dias", Username = "Dias.Adriano" }
            );

            modelBuilder.Entity<Card>().HasData(
            new Card { IdCard = 1,IdUser = 1, isEnabled = true},
            new Card { IdCard = 2,IdUser = 2, isEnabled = true }
             );

            modelBuilder.Entity<ProductRate>().HasData(
            new ProductRate {IdProduct = 1, ProductName = "A4 BW", IsActive = true, ProductCode = "A4BW", Price = 0.05M },
            new ProductRate {IdProduct = 2, ProductName = "A5 BW", IsActive = true, ProductCode = "A5BW", Price = 0.025M },
            new ProductRate {IdProduct = 3, ProductName = "A4 COLOR", IsActive = true, ProductCode = "A4COL", Price = 0.07M },
            new ProductRate {IdProduct = 4, ProductName = "A5 COLOR", IsActive = true, ProductCode = "A5COL", Price = 0.03M }
            );

        }
    }
}
