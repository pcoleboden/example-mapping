using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Boden.Tools.ExampleMapping.Business.Models
{
    public partial class MappingQuestion : MappingEntity
    {
        public bool IsResolved { get; set; }
        public string MappingStoryId { get; set; }
        [JsonIgnore]
        public MappingStory MappingStory { get; set; }

        public MappingQuestion(string id, string description, string mappingStoryId)
            : base(id, description)
        {
            this.MappingStoryId = mappingStoryId;
        }
    }
}
