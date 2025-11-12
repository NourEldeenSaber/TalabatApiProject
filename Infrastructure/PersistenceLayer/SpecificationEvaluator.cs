using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace PersistenceLayer
{
    internal static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity , TKey> (IQueryable<TEntity> inputQuery , ISpecifications<TEntity,TKey> specifications) 
                                                                                                               where TEntity : BaseEntity<TKey>
        {
            var query = inputQuery;
            if(specifications.Criteria != null)
            {
                query = query.Where(specifications.Criteria);
            }
            if(specifications.IncludeExpressions is not null && specifications.IncludeExpressions.Count > 0)
            {
                //foreach (var include in specifications.IncludeExpressions) {
                //    query.Include(include);
                //}

                query = specifications.IncludeExpressions.Aggregate(query,(current,includeExpression) => current.Include(includeExpression));
            }

            return query;
        }
    }
}
