using Microsoft.EntityFrameworkCore;
using SchoolApp.BLL.Data.Contexts;
using SchoolApp.BLL.Repositories;
using SchoolApp.DAL.Entities;
using SchoolApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.ass.BLL.Repositories
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
    // ابدأ باستعلام أساسي لجميع الطلاب
    IQueryable<Student> query = _dbContext.Students; // بافتراض أن _context هو DbContext الخاص بك

    // طبق مرشح البحث فقط إذا لم يكن 'name' فارغًا أو فارغًا
    if (!string.IsNullOrEmpty(name))
    {
        // حول اسم البحث إلى حروف صغيرة مرة واحدة
        string lowerCaseName = name.ToLower();

        // طبق المرشح على الاسم.
        // استخدم ToLower() على جانب قاعدة البيانات للمقارنة غير الحساسة لحالة الأحرف.
        query = query.Where(s => s.Name.ToLower().Contains(lowerCaseName));
    }
    // else: إذا كان name فارغًا أو فارغًا، فسيُرجع الاستعلام جميع الطلاب

    return await query.ToListAsync(); // نفذ الاستعلام
}
    }
}
