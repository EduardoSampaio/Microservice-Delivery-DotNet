using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace BuildingBlocks.Wrappers.http
{
    public static class QueryParamsBuilder<T>
    {
        public static Expression<Func<T, bool>>? BuildProductFilter(string? filterString)
        {
            if (string.IsNullOrWhiteSpace(filterString))
            {
                return null;
            }

            return DynamicExpressionParser.ParseLambda<T, bool>(
                new ParsingConfig(), false, filterString
            );
        }

        public static Func<IQueryable<T>, IOrderedQueryable<T>>? GetOrderByDynamic(string? orderBy, string? sortDirection)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return null;
            }

            var orderString = $"{orderBy} {sortDirection ?? "asc"}";

            return query => query.OrderBy(orderString);
        }
    }
}
