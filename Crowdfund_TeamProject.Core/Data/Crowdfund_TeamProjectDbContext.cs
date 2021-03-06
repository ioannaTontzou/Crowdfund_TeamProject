﻿using Crowdfund_TeamProject.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Crowdfund_TeamProject.Data
{
    public class Crowdfund_TeamProjectDbContext : DbContext
    {
        private readonly string connectionString_;

        public Crowdfund_TeamProjectDbContext() : base()
        {
            connectionString_ = "Server=localhost;Database=Crowdfund;User Id=sa;Password=QWE123!@#";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(connectionString_);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.
                Entity<Backer>().
                ToTable("Backer");

            modelBuilder.
                Entity<Tier>().
                ToTable("Tier");

            modelBuilder.
                Entity<Backer>().
                HasIndex(b => b.Name).
                IsUnique();

            modelBuilder.
                Entity<Backer>().
                HasIndex(b => b.Email).
                IsUnique();

            modelBuilder.
                Entity<Project>().
                ToTable("Project");

            modelBuilder
                .Entity<Project>()
                .Property(p => p.Title)
                .IsRequired();

            modelBuilder.
                Entity<Creator>().
                ToTable("Creator");

            modelBuilder
               .Entity<Creator>()
               .Property(c => c.Name)
               .IsRequired();

            modelBuilder
                .Entity<Creator>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.
                Entity<UpdatePost>().
                ToTable("UpdatePost");
        }
    }
}
