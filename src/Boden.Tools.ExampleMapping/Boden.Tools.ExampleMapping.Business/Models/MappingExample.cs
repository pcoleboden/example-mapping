using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Boden.Tools.ExampleMapping.Business.Models
{
    public partial class MappingExample : MappingEntity
    {
        public string MappingRuleId { get; set; }
        [JsonIgnore]
        public MappingRule MappingRule { get; set; }

        public MappingExample(string id, string description, string mappingRuleId)
            : base(id, description)
        {
            this.MappingRuleId = mappingRuleId;
        }
    }
}
