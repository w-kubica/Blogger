﻿using System.Linq.Expressions;

namespace Blogger.Infrastructure.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static IQueryable<T> OrderByPropertyName<T>(this IQueryable<T> q, string SortField, bool Ascending)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, SortField);
            var exp = Expression.Lambda(prop, param);
            string method = Ascending ? "OrderBy" : "OrderByDescending";
            Type[] types = new Type[] { q.ElementType, exp.Body.Type };
            var rs = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            var t = q.Provider.CreateQuery<T>(rs);
            return q.Provider.CreateQuery<T>(rs);
        }
    }
}
     