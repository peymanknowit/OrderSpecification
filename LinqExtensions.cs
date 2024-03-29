﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Ikea.Mv.Checkout.OrderSpecifications
{
    public static class LinqExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, IOrderSpecification<T> specification)
        {
            if (specification == null) throw new ArgumentNullException(nameof(specification));
            return specification.Invoke(query);
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> query, IOrderSpecification<T> specification)
        {
            if (specification == null) throw new ArgumentNullException(nameof(specification));
            return specification.Invoke(query);
        }

        public static IOrderedEnumerable<T> OrderBy<T>(this IEnumerable<T> query, IOrderSpecification<T> specification)
        {
            if (specification == null) throw new ArgumentNullException(nameof(specification));
            return specification.Invoke(query);
        }

        public static IOrderedEnumerable<T> ThenBy<T>(this IOrderedEnumerable<T> query, IOrderSpecification<T> specification)
        {
            if (specification == null) throw new ArgumentNullException(nameof(specification));
            return specification.Invoke(query);
        }
    }
}
