using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boden.Tools.ExampleMapping.Business.Data
{
    public class SqlServerExampleMappingDbContext : ExampleMappingDbContext
    {
        public string ConnectionString { get; private set; }

        public SqlServerExampleMappingDbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.ConnectionString);
        }
    }
}
