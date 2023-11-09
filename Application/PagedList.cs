namespace Application
{
    public class PagedList<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int TotalRecordsCount { get; set; }
    }
}