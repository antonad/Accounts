using System;
using System.Reflection.Metadata;
using Accounts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Accounts.DAL
{
    public class AccountsDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<EmployeeToPostion> EmployeeToPostions { get; set; }

        public AccountsDbContext(DbContextOptions<AccountsDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeToPostion>()
                .HasKey(p => new { p.EmployeeId, p.PositionId });
            modelBuilder.Entity<EmployeeToPostion>()
                .HasOne(e => e.Position)
                .WithMany(e => e.EmployeeToPostions)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
