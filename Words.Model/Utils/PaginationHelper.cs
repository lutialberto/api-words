using Words.Model.Filters;

namespace Words.Model.Utils
{
    public static class PaginationHelper
    {
        public static IEnumerable<T> ApplyPagination<T>(IEnumerable<T> query, PaginationFilter pagination)
        {
            return query.Skip(pagination.PageSize * pagination.PageNumber).Take(pagination.PageSize);
        }
    }
}
