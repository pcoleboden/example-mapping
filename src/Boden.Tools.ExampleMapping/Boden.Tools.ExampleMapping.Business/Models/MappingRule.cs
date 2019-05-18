using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Boden.Tools.ExampleMapping.Business.Models
{
    public partial class MappingRule : MappingEntity
    {
        public MappingRule()
            : base()
        {
            MappingExamples = new HashSet<MappingExample>();
        }

        public MappingRule(string id, string description, string mappingRuleSectionId)
            : base(id, description)
        {
            this.MappingRuleSectionId = mappingRuleSectionId;
            MappingExamples = new HashSet<MappingExample>();
        }

        public string MappingRuleSectionId { get; set; }

        [JsonIgnore]
        public MappingRuleSection MappingRuleSection { get; set; }
        public ICollection<MappingExample> MappingExamples { get; set; }
    }
}
