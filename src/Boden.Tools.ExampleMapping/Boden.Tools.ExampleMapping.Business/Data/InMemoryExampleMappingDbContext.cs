using System;
using System.Collections.Generic;
using System.Text;
using Boden.Tools.ExampleMapping.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Boden.Tools.ExampleMapping.Business.Data
{
    public class InMemoryExampleMappingDbContext : ExampleMappingDbContext
    {
        private static InMemoryDatabaseRoot databaseRoot = null;
        private static bool hasSampleData = false;

        public static void ResetRoot(bool useSampleData = true)
        {
            databaseRoot = new InMemoryDatabaseRoot();
            hasSampleData = !useSampleData;
        }

        public InMemoryExampleMappingDbContext()
            : base()
        {
            if(databaseRoot == null)
            {
                ResetRoot();
            }

            InitializeSampleData();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbRoot = new InMemoryDatabaseRoot();
            optionsBuilder.UseInMemoryDatabase(databaseName: "ExampleMappingDb", databaseRoot: databaseRoot);
            base.OnConfiguring(optionsBuilder);
        }

        private void InitializeSampleData()
        {
            if (!hasSampleData)
            {
                lock (databaseRoot)
                {
                    if (!hasSampleData)
                    {
                        var story = new MappingStory("S1", "Story 1 Description", "Story 1 Title")
                        {
                            Questions = new List<MappingQuestion>()
                            {
                                new MappingQuestion("Q1_1", "What is Question 1?", "S1"),
                                new MappingQuestion("Q1_2", "What is Question 2?", "S1")
                            },
                            RuleSections = new List<MappingRuleSection>()
                            {
                                new MappingRuleSection("RS1", "Rule Section 1", "S1")
                                {
                                    Rules = new List<MappingRule>()
                                    {
                                        new MappingRule("R1", "Rule 1", "RS1")
                                        {
                                            Examples = new List<MappingExample>()
                                            {
                                                new MappingExample("E1", "Example 1", "R1")
                                            }
                                        }
                                    }
                                }
                            }
                        };
                        this.Stories.Add(story);
                        this.SaveChanges();
                        hasSampleData = true;
                    }
                }
            }
        }
    }
}
