namespace MyWebApiApp.Models
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
            {
             
            PageIndex = pageIndex;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
            }
        public static PaginatedList<T> Create (IQueryable<T> source, int pageIndex , int PageSize)
        {
            var count  = source.Count();
            var item = source.Skip((pageIndex - 1) * PageSize).Take(PageSize).ToList();
            return new PaginatedList<T>(item, count, pageIndex, PageSize);  
        }
            

             

    }
}
