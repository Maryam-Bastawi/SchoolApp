using SchoolApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.DAL.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        //for savechange()
        Task<int> CompleteAsync();
        //for generate repository and return
        IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    }
}
