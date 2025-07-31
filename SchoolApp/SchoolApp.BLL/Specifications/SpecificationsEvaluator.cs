using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.Entities;
using SchoolApp.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.BLL.Specifications
{
    public static class SpecificationsEvaluator<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> InputQuery, ISpecifications<TEntity, TKey> Spec)
        {
            var query = InputQuery;
            if (Spec.Criteria is not null)
            {
                query = query.Where(Spec.Criteria);
            }
            if (Spec.OrderBy is not null)
            {
                query = query.OrderBy(Spec.OrderBy);
            }
            if (Spec.OrderByDesc is not null)
            {
                query = query.OrderByDescending(Spec.OrderByDesc);
            }
            if (Spec.IsPaginationEnabled)
            {
                query = query.Skip(Spec.skip.Value).Take(Spec.take.Value);
            }
            query = Spec.Incloudes.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));

            return query;
        }
    }
}
