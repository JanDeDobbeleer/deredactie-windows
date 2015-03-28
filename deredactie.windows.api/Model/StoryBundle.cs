using System.Collections.Generic;

namespace deredactie.windows.api.Model
{
    public class StoryBundle
    {
        public string id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public List<string> tags { get; set; }
        public List<Content> content { get; set; }
        public string canonical { get; set; }
        public int totalContentCount { get; set; }
        public FirstDirectTextSnippet firstDirectTextSnippet { get; set; }
    }
}