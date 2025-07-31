using SchoolApp.BLL.ModelViews;
using SchoolApp.DAL.Entities;
using SchoolApp.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.BLL.Services.Contract
{
    public interface IStudentService
    {
       
        Task<StudentDto?> GetStudentByIdAsync(string studentById);
        Task<IReadOnlyList<StudentDto>> GetAllStudentsAsync();
        Task<IReadOnlyList<StudentDto>> GetbyNameAsync(string name);


        Task<IReadOnlyList<StudentDto>> GetAllStudentsWithSpecAsync(ISpecifications<Student, string> spec);
        Task<int> GetStudentCountAsync(ISpecifications<Student, string> spec);
        Task<StudentDto?> CreateStudentAsync(CreateStudentDto createDto);

        Task<StudentDto?> UpdateStudentAsync(string studentById, UpdateStudentDto updateDto);
        Task<bool> DeleteStudentAsync(string studentById);
    }
}
