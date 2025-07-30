using company.ass.BLL.Repositories;
using SchoolApp.BLL.Data.Contexts;
using SchoolApp.BLL.Repositories;
using SchoolApp.DAL.Entities;
using SchoolApp.DAL.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.BLL.UnitOfWork.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IStudentRepository _studentRepository;

        private Hashtable _repository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _repository = new Hashtable();
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                // Lazy initialization: create the repository only when it's first accessed
                if (_studentRepository == null)
                {
                    _studentRepository = new StudentRepository(_context);
                }
                return _studentRepository;
            }
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();


        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var type = typeof(TEntity);
            if (!_repository.Contains(type))
            {   //adding
                var repsitory = new GenericRepository<TEntity, TKey>(_context);
                _repository.Add(type, repsitory);

            }
            //return
            return _repository[type] as IGenericRepository<TEntity, TKey>;

        }
    }
}
