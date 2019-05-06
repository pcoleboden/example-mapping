using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boden.Tools.ExampleMapping.Business.Models
{
    /// <summary>A collection of Mapping Rules grouped under a common topic.</summary>
    public class MappingRuleSection : MappingEntity
    {
        /// <summary>The rules contained within the section.</summary>
        public List<MappingRule> Rules { get; set; }

        public string ParentStoryId { get; set; }

        public MappingRuleSection()
        {
        }

        public MappingRuleSection(string id, string description, string parentStoryId)
            : base(id, description)
        {
            this.ParentStoryId = parentStoryId;
        }
    }
}
