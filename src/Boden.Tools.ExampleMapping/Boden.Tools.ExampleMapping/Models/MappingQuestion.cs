using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boden.Tools.ExampleMapping.Models
{
    /// <summary>A question related to a maping story</summary>
    public class MappingQuestion : MappingEntity
    {
        /// <summary>
        /// Whether the question has been answered or not.
        /// We may not need this - could just delete the question.
        /// </summary>
        public bool IsResolved { get; set; }

        public string ParentStoryId { get; set; }
    }
}
