using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boden.Tools.ExampleMapping.Models
{
    /// <summary>A top-level story represented in an example map</summary>
    public class MappingStory : MappingEntity
    {
        /// <summary>Short description of the story, e.g. Jira issue id.</summary>
        public string Title { get; set; }

        /// <summary>The rules making up the story</summary>
        public List<MappingRuleSection> RuleSections { get; set; }

        /// <summary>The questions within the story</summary>
        public List<MappingQuestion> Questions { get; set; }
    }
}
