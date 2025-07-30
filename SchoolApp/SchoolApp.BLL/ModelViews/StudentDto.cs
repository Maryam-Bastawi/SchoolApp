using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SchoolApp.BLL.ModelViews
{
    public class StudentDto
    {
        // رقم الطالب (المفتاح الأساسي)
        public string Id { get; set; } 
        // اسم الطالب عربي
        public string Name { get; set; } 
        // اسم الطالب إنجليزي
        public string? EnglishName { get; set; }
        public string? Email { get; set; }

        // رقم هاتف 1
        public string? Mobile1 { get; set; }
        // رقم هاتف 2 (لو 'MObILe' هو رقم هاتف إضافي)
        public string? Mobile2 { get; set; }
        // موبايل (لو 'PHON' هو حقل آخر لرقم هاتف)
        public string? Phone { get; set; }
        // الموقع
        public string? Location { get; set; }
        // ولي الأمر
        public string? Respons { get; set; }
        // رقم الهوية
        public string? IdNumber { get; set; } 
        // تاريخ إصدار الهوية (سلسلة نصية لتجنب مشاكل التنسيق)
        public string? IdIssueDateString { get; set; }
        // تاريخ انتهاء الهوية (سلسلة نصية لتجنب مشاكل التنسيق)
        public string? IdEndDateString { get; set; }
        //// الرقم القومي أو المعرف الوطني
        public string? NationalId { get; set; }
        // صورة الطالب (كـ URL إذا كنت ستخزنها كـ ملفات أو Base64 إذا كانت صغيرة جداً)

        public string? ImgName { get; set; }
        public IFormFile? StudentImage { get; set; }
        // السيارة
        public string? VehicleId { get; set; }
        // المرحلة الدراسية
        public string? StagesId { get; set; }
        // الصف الدراسي
        public string? GradesId { get; set; }
        // حالة الطالب
        public string? StudentStatusId { get; set; }
        // الصف التالي (مع ملاحظة أنها int(1,0) في DB، ممكن تكون bool أو byte)
        public bool NextGrade { get; set; }
        // الفصل
        public string? Classroom { get; set; }
        // المنطقة
        public string? AreaId { get; set; }
        // المدرسة
        public string? SchoolId { get; set; }
        public bool StopSms { get; set; }
        // النوع (ذكر/أنثى) (int(1,0) في DB، ممكن تكون bool أو byte)
        public bool StudentSex { get; set; }
        // رقم جواز السفر
        public string? Passport { get; set; }
        public string? BirthDateString { get; set; }
        // ملاحظات
        public string? Note { get; set; }
        // عام جديد (int(1,0) في DB، ممكن تكون bool)
        public bool IsNewYear { get; set; }
        // خصائص إضافية لو موجودة في الـ BaseEntity زي تاريخ الإنشاء والتعديل

    }
}
