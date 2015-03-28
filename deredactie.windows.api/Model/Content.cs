using System.Collections.Generic;

namespace deredactie.windows.api.Model
{
    public class Content
    {
        public string id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string format { get; set; }
        public List<string> tags { get; set; }
        public List<Content> content { get; set; }
        public string publicationDate { get; set; }
        public string lastUpdateTime { get; set; }
        public List<object> channels { get; set; }
        public string externalPermaLink { get; set; }
        public string canonical { get; set; }
        public string externalLink { get; set; }
        public FirstDirectTextSnippet firstDirectTextSnippet { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public string @abstract { get; set; }
        public string source { get; set; }
        public List<object> displayTimes { get; set; }
    }
}