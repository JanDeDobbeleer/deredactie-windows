using System.Collections.Generic;

namespace deredactie.windows.api.Model
{
    public class Row
    {
        public Content bundle { get; set; }
        public List<object> links { get; set; }
        public StoryBundle storyBundle { get; set; }
    }
}