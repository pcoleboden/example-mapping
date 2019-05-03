using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boden.Tools.ExampleMapping.Models
{
    /// <summary>A collection of Mapping Rules grouped under a common topic.</summary>
    public class MappingRuleSection : MappingEntity
    {
        /// <summary>The rules contained within the section.</summary>
        public List<MappingRule> Rules { get; set; }
    }
}
