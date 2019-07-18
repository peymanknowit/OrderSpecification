using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ikea.Mv.Checkout.OrderSpecifications
{
    public abstract class OrderSpecification<T> : IOrderSpecification<T>
    {
        public Sort Sort { get; set; }

        protected OrderSpecification(Sort direction)
        {
            Sort = direction;
        }

        public ThenBySpecification<T> ThenBy(IOrderSpecification<T> other)
        {
            var orderList = new List<IOrderSpecification<T>> { this };
            return new ThenBySpecification<T>(orderList, other);
        }

        public IOrderedQueryable<T> Invoke(IQueryable<T> query)
        {
            return Sort == Sort.Descending
                ? query.OrderByDescending(AsExpression())
                : query.OrderBy(AsExpression());
        }

        public IOrderedQueryable<T> Invoke(IOrderedQueryable<T> query)
        {
            return Sort == Sort.Descending
                ? query.ThenByDescending(AsExpression())
                : query.ThenBy(AsExpression());
        }

        public IOrderedEnumerable<T> Invoke(IEnumerable<T> collection)
        {
            return Sort == Sort.Descending
                ? collection.OrderByDescending(AsExpression().Compile())
                : collection.OrderBy(AsExpression().Compile());
        }

        public IOrderedEnumerable<T> Invoke(IOrderedEnumerable<T> collection)
        {
            return Sort == Sort.Descending
                ? collection.ThenByDescending(AsExpression().Compile())
                : collection.ThenBy(AsExpression().Compile());
        }

        public abstract Expression<Func<T, IComparable>> AsExpression();
    }
}
