using Boden.Tools.ExampleMapping.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boden.Tools.ExampleMapping.Business.Data
{
    public abstract class ExampleMappingDbContext : DbContext
    {
        public DbSet<MappingStory> Stories { get; set; }

        public DbSet<MappingRule> Rules { get; set; }

        public DbSet<MappingExample> Examples { get; set; }

        public DbSet<MappingQuestion> Questions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<MappingRule>().Property(r => r.ParentRuleSectionId).ValueGeneratedNever();
        }
    }
}
