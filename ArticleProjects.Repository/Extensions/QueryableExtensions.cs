﻿using System;
using System.Linq;
using Nuevo.Repository.Generic;

namespace ArticleProjects.Repository.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query,
            Func<IIncludable<T>, IIncludable> includes)
            where T : class
        {
            if (includes == null)
                return query;

            var includable = (Includable<T>)includes(new Includable<T>(query));
            return includable.Input;
        }
    }
}
