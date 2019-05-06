using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Boden.Tools.ExampleMapping.Business.Models
{
    /// <summary>base class for example mapping entities.</summary>
    public abstract class MappingEntity
    {
        /// <summary>Unique ID of the entity. Can be used to identify the entity in code.</summary>
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        /// <summary>The human-friendly description of the entity.</summary>
        public string Description { get; set; }

        public MappingEntity()
        {
        }

        public MappingEntity(string id, string description = null)
        {
            this.Id = id;
            this.Description = description;
        }
    }
}
