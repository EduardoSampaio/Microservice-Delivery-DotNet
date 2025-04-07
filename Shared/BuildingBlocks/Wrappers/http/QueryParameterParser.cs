using Microsoft.AspNetCore.Http;

namespace BuildingBlocks.Wrappers.http
{
    public static class QueryParameterParser
    {
        public static bool TryParseQueryParameters(IQueryCollection query, out QueryParameters result)
        {
            result = new QueryParameters();

            // PageIndex
            if (query.TryGetValue("pageIndex", out var pageIndexValue) &&
                int.TryParse(pageIndexValue, out var pageIndex))
            {
                result.PageIndex = pageIndex;
            }

            // PageSize
            if (query.TryGetValue("pageSize", out var pageSizeValue) &&
                int.TryParse(pageSizeValue, out var pageSize))
            {
                result.PageSize = pageSize;
            }

            // Filter
            if (query.TryGetValue("filter", out var filter))
            {
                result.Filter = filter;
            }

            // OrderBy
            if (query.TryGetValue("orderBy", out var orderBy))
            {
                result.OrderBy = orderBy;
            }

            // SortDirection
            if (query.TryGetValue("sortDirection", out var sortDirection))
            {
                var dir = sortDirection.ToString().ToLower();
                if (dir == "asc" || dir == "desc")
                {
                    result.SortDirection = dir;
                }
                else
                {
                    return false; // Invalid direction
                }
            }

            return true;
        }
    }
}
