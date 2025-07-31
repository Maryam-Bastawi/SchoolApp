using SchoolApp.DAL.Entities;
using SchoolApp.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.DAL.Interface
{
    public interface IStudentRepository : IGenericRepository<Student, string> 
    {

         Task<IEnumerable<Student>> GetbyNameAsync(string name);
        Task<bool> AnyByIdNumberAsync(string idNumber);

        Task<bool> AnyByPassportAsync(string passport);
    }
}
