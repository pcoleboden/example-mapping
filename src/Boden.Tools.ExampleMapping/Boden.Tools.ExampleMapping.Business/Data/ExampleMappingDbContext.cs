using Boden.Tools.ExampleMapping.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boden.Tools.ExampleMapping.Business.Data
{
    public abstract class ExampleMappingDbContext : DbContext
    {
        public ExampleMappingDbContext()
        {
        }

        public ExampleMappingDbContext(DbContextOptions<ExampleMappingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MappingExample> MappingExamples { get; set; }
        public virtual DbSet<MappingQuestion> MappingQuestions { get; set; }
        public virtual DbSet<MappingRule> MappingRules { get; set; }
        public virtual DbSet<MappingRuleSection> MappingRuleSections { get; set; }
        public virtual DbSet<MappingStory> MappingStories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MappingExample>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.MappingRuleId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MappingRule)
                    .WithMany(p => p.MappingExamples)
                    .HasForeignKey(d => d.MappingRuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MappingExamples_MappingRules");
            });

            modelBuilder.Entity<MappingQuestion>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.MappingStoryId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MappingStory)
                    .WithMany(p => p.MappingQuestions)
                    .HasForeignKey(d => d.MappingStoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MappingQuestions_MappingStories");
            });

            modelBuilder.Entity<MappingRule>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.MappingRuleSectionId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MappingRuleSection)
                    .WithMany(p => p.MappingRules)
                    .HasForeignKey(d => d.MappingRuleSectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MappingRules_MappingRuleSections");
            });

            modelBuilder.Entity<MappingRuleSection>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.MappingStoryId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MappingStory)
                    .WithMany(p => p.MappingRuleSections)
                    .HasForeignKey(d => d.MappingStoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MappingRuleSections_MappingStories");
            });

            modelBuilder.Entity<MappingStory>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Title).HasMaxLength(100);
            });
        }
    }
}
