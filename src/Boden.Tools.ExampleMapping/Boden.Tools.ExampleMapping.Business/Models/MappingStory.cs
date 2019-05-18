using System;
using System.Collections.Generic;

namespace Boden.Tools.ExampleMapping.Business.Models
{
    public partial class MappingStory : MappingEntity
    {
        public MappingStory()
            : base()
        {
            MappingQuestions = new HashSet<MappingQuestion>();
            MappingRuleSections = new HashSet<MappingRuleSection>();
        }

        public MappingStory(string id, string description, string title)
            : base(id, description)
        {
            this.Title = title;
            MappingQuestions = new HashSet<MappingQuestion>();
            MappingRuleSections = new HashSet<MappingRuleSection>();
        }

        public string Title { get; set; }

        public ICollection<MappingQuestion> MappingQuestions { get; set; }
        public ICollection<MappingRuleSection> MappingRuleSections { get; set; }
    }
}
