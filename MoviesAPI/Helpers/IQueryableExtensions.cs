using MoviesAPI.DTOs;
using System.Runtime.CompilerServices;

namespace MoviesAPI.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T>Paginate<T>(this IQueryable<T>queryable,PaginationDTO paginationDTO)
        {

            int pageNumber = paginationDTO.Page;
            int pageSize = paginationDTO.RecordsPerPage;

            int offset = (pageNumber - 1) * pageSize;
            offset = Math.Max(offset, 0); // Ensure offset is non-negative

            return queryable
                .Skip(offset)
                .Take(pageSize);
        }


    }
}
