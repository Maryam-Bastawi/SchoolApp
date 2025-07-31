using Microsoft.EntityFrameworkCore;
using SchoolApp.BLL.Data.Contexts;
using SchoolApp.BLL.Specifications;
using SchoolApp.DAL.Entities;
using SchoolApp.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.BLL.Repositories
{
	public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
	{
        private protected readonly AppDbContext _dbContext;


        public GenericRepository(AppDbContext dbContext)
            {
            _dbContext = dbContext;
            }
            public async Task<IEnumerable<TEntity>> GetAllAsync()
            {

                return await _dbContext.Set<TEntity>().ToListAsync();
            }
            public async Task AddAsync(TEntity entity)
            {
                await _dbContext.AddAsync(entity);

            }
            public async Task UpdateAsync(TEntity entity)
            {
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync(); // 
            }
            public async Task DeleteAsync(TEntity entity)
            {
                _dbContext.Remove(entity);
                await _dbContext.SaveChangesAsync(); // 
            }



            public async Task<TEntity> GetByIdAsync(TKey id)
            {
                return await _dbContext.Set<TEntity>().FindAsync(id);
            }


            public async Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity, TKey> Spec)
            {
                //return  await SpecificationsEvaluator<TEntity, TKey>.GetQuery(_context.Set<TEntity>(), Spec).ToListAsync();
                return await ApplySpecifications(Spec).ToListAsync();
            }


            public async Task<TEntity> GetByIdWithSpecAsync(ISpecifications<TEntity, TKey> Spec)
            {
                //return await SpecificationsEvaluator<TEntity, TKey>.GetQuery(_context.Set<TEntity>(), Spec).FirstOrDefaultAsync();
                return await ApplySpecifications(Spec).FirstOrDefaultAsync();
            }

            private IQueryable<TEntity> ApplySpecifications(ISpecifications<TEntity, TKey> Spec)
            {

                return SpecificationsEvaluator<TEntity, TKey>.GetQuery(_dbContext.Set<TEntity>(), Spec);
            }

            public async Task<int> GetCountWithAsync(ISpecifications<TEntity, TKey> Spec)
            {
                return await ApplySpecifications(Spec).CountAsync();
            }

    }
}
