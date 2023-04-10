namespace DrugStore.API.Services
{
    public class PaginationMetadata
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        public PaginationMetadata(int totalCount, int pageSize, int currentPage)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }

        public static PaginationMetadata Create<T>(IQueryable<T> source, int pageSize, int currentPage)
        {
            var totalCount = source.Count();

            return new PaginationMetadata(totalCount, pageSize, currentPage);
        }
    }
}