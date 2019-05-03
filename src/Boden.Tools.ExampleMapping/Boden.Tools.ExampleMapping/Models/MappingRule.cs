using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boden.Tools.ExampleMapping.Models
{
    /// <summary>A single rule within a story. Analogous to a piece of acceptance criteria.</summary>
    public class MappingRule : MappingEntity
    {
        /// <summary>The collection of examples which help to illustrate the rule.</summary>
        public List<MappingExample> Examples { get; set; }
    }
}
