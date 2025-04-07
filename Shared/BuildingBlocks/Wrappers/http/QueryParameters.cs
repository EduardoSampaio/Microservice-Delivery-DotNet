namespace BuildingBlocks.Wrappers.http
{
    public class QueryParameters
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 10;
        public string? Filter { get; set; }
        public string? OrderBy { get; set; }
        public string? SortDirection { get; set; }
    }

}
