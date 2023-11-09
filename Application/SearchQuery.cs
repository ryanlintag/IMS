namespace Application
{
    public record SearchQuery
    {
        public string SearchValue { get; private set; } = string.Empty;
        public int PageNumber { get; private set; } = 1;
        public int PageSize { get; private set; } = 20;
        public string SortProperty { get; private set; } = string.Empty;
        public string SortOrder { get; private set; } = string.Empty;
        public SearchQuery(string searchValue, int pageNumber, int pageSize, string sortProperty, string sortOrder)
        {
            this.SearchValue = searchValue;
            if(pageNumber < 1) pageNumber = 1;
            this.PageNumber = pageNumber;
            if(pageSize < 20) pageSize = 20;
            this.PageSize = pageSize;
            this.SortProperty = sortProperty; 
            this.SortOrder = sortOrder;
        }
    }
}
