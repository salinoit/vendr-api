using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Vendr.Infra.CrossCutting.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<IEnumerable<T>> ToListPagedAsync<T>(this IQueryable<T> query, int page, int quantity)
        {
            if (page <= 0)
                page = 1;

            var skip = (page - 1) * quantity;

            var list = await query.Skip(skip).Take(quantity).ToListAsync();

            return list;
        }

        public static async Task<IEnumerable<T>> ToListPagedAsync<T>(this IEnumerable<T> items, int page, int quantity)
        {
            if (page <= 0)
                page = 1;

            var skip = (page - 1) * quantity;

            var list = await items.Skip(skip).Take(quantity).AsQueryable().ToListAsync<T>();

            return list;
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string field, string direction)
        {
            if (!string.IsNullOrEmpty(field) && !string.IsNullOrEmpty(direction))
            {
                MemberExpression property = null;
                ParameterExpression parameter = Expression.Parameter(query.ElementType, String.Empty);

                if (string.IsNullOrEmpty(field))
                {
                    field = parameter.Type.GetProperties().First().Name;
                }

                foreach (var propriedade in field.Split('.'))
                {
                    if (property == null)
                        property = Expression.Property(parameter, propriedade);
                    else
                        property = Expression.Property(property, propriedade);
                }

                LambdaExpression lambda = Expression.Lambda(property, parameter);

                string methodName = (direction == "Descending") ? "OrderByDescending" : "OrderBy";

                Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName, new Type[] { query.ElementType, property.Type }, query.Expression, Expression.Quote(lambda));

                query = query.Provider.CreateQuery<T>(methodCallExpression);
            }

            return query;
        }
    }
}
