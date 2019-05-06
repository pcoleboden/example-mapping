using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boden.Tools.ExampleMapping.Business.Data;
using Boden.Tools.ExampleMapping.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Boden.Tools.ExampleMapping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MappingStoryController : ControllerBase
    {
        private readonly MappingStoryRepository db;

        public MappingStoryController(MappingStoryRepository db)
        {
            this.db = db;
        }

        // GET: api/MappingStory
        [HttpGet]
        public IEnumerable<MappingStory> Get()
        {
            //InMemoryExampleMappingDbContext.ResetRoot();
            return db.GetAll();
        }

        // GET: api/MappingStory/5
        [HttpGet("{id}", Name = "Get")]
        public MappingStory Get(string id)
        {
            return db.GetById(id);
        }

        // POST: api/MappingStory
        [HttpPost]
        public void Post([FromBody] MappingStory value)
        {
            throw new NotImplementedException();
        }

        // PUT: api/MappingStory/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] MappingStory value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/MappingStory/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
