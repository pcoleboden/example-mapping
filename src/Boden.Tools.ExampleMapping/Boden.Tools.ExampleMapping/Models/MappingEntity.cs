using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boden.Tools.ExampleMapping.Models
{
    /// <summary>base class for example mapping entities.</summary>
    public abstract class MappingEntity
    {
        /// <summary>Unique ID of the entity. Can be used to identify the entity in code.</summary>
        public string Id { get; set; }

        /// <summary>The human-friendly description of the entity.</summary>
        public string Description { get; set; }
    }
}
