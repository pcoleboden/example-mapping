using Boden.Tools.ExampleMapping.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boden.Tools.ExampleMapping.Business.Data
{
    public class MappingStoryRepository
    {
        private readonly ExampleMappingDbContext dbContext;

        public MappingStoryRepository(ExampleMappingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<MappingStory> GetAll() => this.dbContext.Stories
            .Include(dbContext.GetIncludePaths<MappingStory>())
            .ToList();

        public MappingStory GetById(string id) => this.dbContext.Stories.Where(s => s.Id == id)
            .Include(dbContext.GetIncludePaths<MappingStory>())
            .FirstOrDefault();
    }
}
