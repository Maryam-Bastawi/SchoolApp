using SchoolApp.DAL.Entities;
using SchoolApp.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace SchoolApp.BLL.Specifications
{
    public class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        public Expression<Func<TEntity, bool>> Criteria { get; set; }
        public List<Expression<Func<TEntity, object>>> Incloudes { get; set; } = new List<Expression<Func<TEntity, object>>>();
        public Expression<Func<TEntity, object>> OrderBy { get; set; } = null;
        public Expression<Func<TEntity, object>> OrderByDesc { get; set; } = null;
        public int? skip { get; set ; }
        public int? take { get; set ; }
        public bool IsPaginationEnabled { get; set ; }


        public BaseSpecifications()
        {
            
        }
        public BaseSpecifications(Expression<Func<TEntity, bool>> expression)
        {
            Criteria = expression;
        }

        public void AddOrderBy(Expression<Func<TEntity, object>> expression)
        {
            OrderBy = expression;
        }
        public void AddOrderByDesc(Expression<Func<TEntity, object>> expression)
        {
            OrderByDesc = expression;
        }
        public void ApplyPagination(int Skip, int Take)
        {
            IsPaginationEnabled = true;
            skip = Skip;
            take = Take;

        }
    }
}
