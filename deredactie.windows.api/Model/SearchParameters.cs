namespace deredactie.windows.api.Model
{
    public class SearchParameters
    {
        public string startDate { get; set; }
        public int page { get; set; }
        public object tag { get; set; }
        public int pageSize { get; set; }
        public string channel { get; set; }
        public int defaultPageSize { get; set; }
    }
}