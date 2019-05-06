using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boden.Tools.ExampleMapping.Business.Models
{
    /// <summary>A example used to demonstrate an individual rule.</summary>
    public class MappingExample : MappingEntity
    {
        public string ParentRuleId { get; set; }

        public MappingExample()
        {
        }

        public MappingExample(string id, string description, string parentRuleId)
            : base(id, description)
        {
            this.ParentRuleId = parentRuleId;
        }
    }
}
