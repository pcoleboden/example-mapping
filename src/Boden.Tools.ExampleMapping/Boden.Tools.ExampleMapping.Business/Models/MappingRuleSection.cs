using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Boden.Tools.ExampleMapping.Business.Models
{
    public partial class MappingRuleSection : MappingEntity
    {
        public MappingRuleSection()
            : base()
        {
            MappingRules = new HashSet<MappingRule>();
        }

        public MappingRuleSection(string id, string description, string mappingStoryId)
            : base(id, description)
        {
            this.MappingStoryId = mappingStoryId;
            MappingRules = new HashSet<MappingRule>();
        }

        public string MappingStoryId { get; set; }
        [JsonIgnore]
        public MappingStory MappingStory { get; set; }
        public ICollection<MappingRule> MappingRules { get; set; }
    }
}
