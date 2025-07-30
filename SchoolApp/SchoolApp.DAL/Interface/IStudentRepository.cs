using SchoolApp.DAL.Entities;
using SchoolApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.DAL.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student, string> 
    {

         Task<IEnumerable<Student>> GetbyNameAsync(string name);
        Task<bool> AnyByIdNumberAsync(string idNumber);


    }
}
