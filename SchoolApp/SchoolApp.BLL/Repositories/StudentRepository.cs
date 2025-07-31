using Microsoft.EntityFrameworkCore;
using SchoolApp.BLL.Data.Contexts;
using SchoolApp.BLL.Repositories;
using SchoolApp.DAL.Entities;
using SchoolApp.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.BLL.Repositories
{
    public class StudentRepository : GenericRepository<Student, string>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<bool> AnyByIdNumberAsync(string idNumber)
        {
            return await _dbContext.Students.AnyAsync(s => s.IdNumber == idNumber);

        }



        public async Task<IEnumerable<Student>> GetbyNameAsync(string name)
        {
            return await _dbContext.Students.Where(e => e.Name.ToLower() == name.ToLower()).Include(e => e.IdNumber).Include(e => e.GradesId).ToListAsync();



        }
        public async Task<bool> AnyByPassportAsync(string passport)
        {
            return await _dbContext.Students.AnyAsync(s => s.Passport == passport);
        }
    }
}