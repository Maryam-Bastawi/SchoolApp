using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.BLL.ModelViews
{
    public class UpdateStudentDto
    {
      
        // اسم الطالب عربي (مطلوب)
        [Required(ErrorMessage = "اسم الطالب العربي مطلوب")]
        [StringLength(65, ErrorMessage = "الاسم العربي لا يمكن أن يتجاوز 65 حرفًا")]
        public string Name { get; set; }  // حافظت على string.Empty ليتوافق مع DTO العرض، لكن يفضل null في DTO الإدخال

        // اسم الطالب إنجليزي (اختياري)
        [StringLength(65, ErrorMessage = "الاسم الإنجليزي لا يمكن أن يتجاوز 65 حرفًا")]
        public string? EnglishName { get; set; }
        [EmailAddress(ErrorMessage = "صيغة البريد الإلكتروني غير صحيحة.")]
        [StringLength(100, ErrorMessage = "يجب ألا يتجاوز طول البريد الإلكتروني 100 حرف.")]
        // [Display(Name = "البريد الإلكتروني")] // يمكن إضافتها إذا كنت تستخدم هذا الـ DTO في نموذج إدخال
        public string? Email { get; set; }

        // رقم هاتف 1
        [StringLength(15, ErrorMessage = "رقم هاتف 1 لا يمكن أن يتجاوز 15 رقمًا")]
        [Phone(ErrorMessage = "صيغة رقم هاتف 1 غير صحيحة.")]
        public string? Mobile1 { get; set; }

        // رقم هاتف 2
        [StringLength(15, ErrorMessage = "رقم هاتف 2 لا يمكن أن يتجاوز 15 رقمًا")]
        [Phone(ErrorMessage = "صيغة رقم هاتف 2 غير صحيحة.")]
        public string? Mobile2 { get; set; }

        // موبايل (رقم هاتف إضافي / ثابت)
        [StringLength(20, ErrorMessage = "رقم الهاتف لا يمكن أن يتجاوز 20 رقمًا")]
        [Phone(ErrorMessage = "صيغة رقم الهاتف غير صحيحة.")]
        public string? Phone { get; set; }

        // الموقع
        [StringLength(65, ErrorMessage = "الموقع لا يمكن أن يتجاوز 65 حرفًا")]
        public string? Location { get; set; }

        // ولي الأمر
        [StringLength(65, ErrorMessage = "ولي الأمر لا يمكن أن يتجاوز 65 حرفًا")]
        public string? Respons { get; set; }

        // رقم الهوية
        [StringLength(11, ErrorMessage = "رقم الهوية لا يمكن أن يتجاوز 11 حرفًا")]
        public string? IdNumber { get; set; }

        // تاريخ إصدار الهوية (سلسلة نصية)
        [StringLength(10, ErrorMessage = "تاريخ إصدار الهوية يجب أن يكون 10 أحرف (YYYY-MM-DD)")]
        public string? IdIssueDateString { get; set; }

        // تاريخ انتهاء الهوية (سلسلة نصية)
        [StringLength(10, ErrorMessage = "تاريخ انتهاء الهوية يجب أن يكون 10 أحرف (YYYY-MM-DD)")]
        public string? IdEndDateString { get; set; }

        // الرقم القومي أو المعرف الوطني
        [StringLength(65, ErrorMessage = "الرقم القومي لا يمكن أن تتجاوز 65 حرفًا")]
        public string? NationalId { get; set; }

        [Display(Name = "صورة الطالب")]
        public string? ImgName { get; set; }
        public IFormFile? StudentImage { get; set; }
        public bool RemoveExistingImage { get; set; }

        // السيارة
        [StringLength(10, ErrorMessage = "معرف السيارة لا يمكن أن يتجاوز 10 أحرف")]
        public string? VehicleId { get; set; }

        // المرحلة الدراسية
        [StringLength(10, ErrorMessage = "معرف المرحلة الدراسية لا يمكن أن يتجاوز 10 أحرف")]
        public string? StagesId { get; set; }

        // الصف الدراسي
        [StringLength(10, ErrorMessage = "معرف الصف الدراسي لا يمكن أن يتجاوز 10 أحرف")]
        public string? GradesId { get; set; }

        // حالة الطالب
        [StringLength(10, ErrorMessage = "معرف حالة الطالب لا يمكن أن يتجاوز 10 أحرف")]
        public string? StudentStatusId { get; set; }

        // الصف التالي (bool لتمثيل 0 أو 1)
        public bool NextGrade { get; set; }

        // الفصل
        [StringLength(10, ErrorMessage = "الفصل لا يمكن أن يتجاوز 10 أحرف")]
        public string? Classroom { get; set; }

        // المنطقة
        [StringLength(15, ErrorMessage = "معرف المنطقة لا يمكن أن يتجاوز 15 حرفًا")]
        public string? AreaId { get; set; }

        // المدرسة
        [StringLength(15, ErrorMessage = "معرف المدرسة لا يمكن أن يتجاوز 15 حرفًا")]
        public string? SchoolId { get; set; }

        // هل يتم إيقاف رسائل SMS (bool)
        public bool StopSms { get; set; }

        // النوع (ذكر/أنثى) (bool لتمثيل 0 أو 1)
        public bool StudentSex { get; set; }

        // رقم جواز السفر
        [StringLength(20, ErrorMessage = "رقم جواز السفر لا يمكن أن يتجاوز 20 حرفًا")]
        public string? Passport { get; set; }

        // تاريخ الميلاد (سلسلة نصية)
        [StringLength(10, ErrorMessage = "تاريخ الميلاد يجب أن يكون 10 أحرف (YYYY-MM-DD)")]
        public string? BirthDateString { get; set; }

        // ملاحظات
        [StringLength(100, ErrorMessage = "الملاحظات لا يمكن أن تتجاوز 100 حرف")]
        public string? Note { get; set; }

        // عام جديد (bool)
        public bool IsNewYear { get; set; }

    }
}
