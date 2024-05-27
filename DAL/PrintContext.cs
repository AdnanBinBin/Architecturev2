
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
           //  builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ArchitecturePrintUseCaseV5");
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
           .HasMany(u => u.Transactions) // Un utilisateur peut avoir plusieurs transactions
           .WithOne(t => t.User)         // Chaque transaction appartient à un seul utilisateur
           .HasForeignKey(t => t.IdUser);
        }
    }
}
