using SchoolApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.DAL.Interface
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity, TKey> Spec);
        Task<TEntity> GetByIdAsync(TKey id);
        Task<TEntity> GetByIdWithSpecAsync(ISpecifications<TEntity, TKey> Spec);
        Task<int> GetCountWithAsync(ISpecifications<TEntity, TKey> Spec);

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);

    }
}
