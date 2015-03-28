using System.Collections.Generic;

namespace deredactie.windows.api.Model
{
    public class ContentRoot
    {
        public List<Row> rows { get; set; }
        public int size { get; set; }
        public int totalSize { get; set; }
        public int maxSize { get; set; }
        public SearchParameters searchParameters { get; set; }
        public List<Link> links { get; set; }
    }
}
