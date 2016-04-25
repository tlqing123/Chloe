﻿using Chloe.Core;
using Chloe.Database;
using Chloe.Infrastructure;
using Chloe.Query.QueryExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chloe.Query
{
    class OrderedQuery<T> : Query<T>, IOrderedQuery<T>
    {
        public OrderedQuery(DbContext dbContext, QueryExpression exp)
            : base(dbContext, exp)
        {

        }
        public IOrderedQuery<T> ThenBy<K>(Expression<Func<T, K>> predicate)
        {
            OrderExpression e = new OrderExpression(QueryExpressionType.ThenBy, typeof(T), this.QueryExpression, predicate);
            return new OrderedQuery<T>(this.DbContext, e);
        }
        public IOrderedQuery<T> ThenByDesc<K>(Expression<Func<T, K>> predicate)
        {
            OrderExpression e = new OrderExpression(QueryExpressionType.ThenByDesc, typeof(T), this.QueryExpression, predicate);
            return new OrderedQuery<T>(this.DbContext, e);
        }
    }
}