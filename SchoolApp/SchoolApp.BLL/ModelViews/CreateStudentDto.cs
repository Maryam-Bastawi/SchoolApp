using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.BLL.ModelViews
{
    public class CreateStudentDto
    {
       
            // اسم الطالب عربي (مطلوب)
            [Display(Name = "الاسم (عربي)")]
            [Required(ErrorMessage = "اسم الطالب العربي مطلوب")]
            [StringLength(65, ErrorMessage = "الاسم العربي لا يمكن أن يتجاوز 65 حرفًا")]
            public string Name { get; set; }

            // اسم الطالب إنجليزي (اختياري)
            [Display(Name = "الاسم (إنجليزي)")]
            [StringLength(65, ErrorMessage = "الاسم الإنجليزي لا يمكن أن يتجاوز 65 حرفًا")]
            public string? EnglishName { get; set; }

            [Display(Name = "البريد الإلكتروني")]
            [EmailAddress(ErrorMessage = "صيغة البريد الإلكتروني غير صحيحة.")]
            [StringLength(100, ErrorMessage = "يجب ألا يتجاوز طول البريد الإلكتروني 100 حرف.")]
            public string? Email { get; set; }

            // رقم هاتف 1
            [Display(Name = "رقم الهاتف 1")]
            [StringLength(15, ErrorMessage = "رقم هاتف 1 لا يمكن أن يتجاوز 15 رقمًا")]
            [Phone(ErrorMessage = "صيغة رقم هاتف 1 غير صحيحة.")]
            public string? Mobile1 { get; set; }

            // رقم هاتف 2
            [Display(Name = "رقم الهاتف 2")]
            [StringLength(15, ErrorMessage = "رقم هاتف 2 لا يمكن أن يتجاوز 15 رقمًا")]
            [Phone(ErrorMessage = "صيغة رقم هاتف 2 غير صحيحة.")]
            public string? Mobile2 { get; set; }

            // موبايل (رقم هاتف إضافي / ثابت)
            [Display(Name = "هاتف ثابت")]
            [StringLength(20, ErrorMessage = "رقم الهاتف لا يمكن أن يتجاوز 20 رقمًا")]
            [Phone(ErrorMessage = "صيغة رقم الهاتف غير صحيحة.")]
            public string? Phone { get; set; }

            // الموقع
            [Display(Name = "الموقع")]
            [StringLength(65, ErrorMessage = "الموقع لا يمكن أن يتجاوز 65 حرفًا")]
            public string? Location { get; set; }

            // ولي الأمر
            [Display(Name = "ولي الأمر")]
            [StringLength(65, ErrorMessage = "ولي الأمر لا يمكن أن يتجاوز 65 حرفًا")]
            public string? Respons { get; set; }

            // رقم الهوية
            [Display(Name = "رقم الهوية")]
            [StringLength(11, ErrorMessage = "رقم الهوية لا يمكن أن يتجاوز 11 حرفًا")]
            public string? IdNumber { get; set; }

            // تاريخ إصدار الهوية (سلسلة نصية)
            [Display(Name = "تاريخ إصدار الهوية")]
            [StringLength(10, ErrorMessage = "تاريخ إصدار الهوية يجب أن يكون 10 أحرف (YYYY-MM-DD)")]
            public string? IdIssueDateString { get; set; }

            // تاريخ انتهاء الهوية (سلسلة نصية)
            [Display(Name = "تاريخ انتهاء الهوية")]
            [StringLength(10, ErrorMessage = "تاريخ انتهاء الهوية يجب أن يكون 10 أحرف (YYYY-MM-DD)")]
            public string? IdEndDateString { get; set; }

            // الرقم القومي أو المعرف الوطني
            [Display(Name = "الرقم القومي")]
            [StringLength(65, ErrorMessage = "الرقم القومي لا يمكن أن تتجاوز 65 حرفًا")]
            public string? NationalId { get; set; }

            [Display(Name = "صورة الطالب")]
        public string? ImgName { get; set; }
        public IFormFile? StudentImage { get; set; }
       
        // السيارة
        [Display(Name = "معرف السيارة")]
            [StringLength(10, ErrorMessage = "معرف السيارة لا يمكن أن يتجاوز 10 أحرف")]
            public string? VehicleId { get; set; }

            // المرحلة الدراسية
            [Display(Name = "المرحلة الدراسية")]
            [StringLength(10, ErrorMessage = "معرف المرحلة الدراسية لا يمكن أن يتجاوز 10 أحرف")]
            public string? StagesId { get; set; }

            // الصف الدراسي
            [Display(Name = "الصف الدراسي")]
            [StringLength(10, ErrorMessage = "معرف الصف الدراسي لا يمكن أن يتجاوز 10 أحرف")]
            public string? GradesId { get; set; }

            // حالة الطالب
            [Display(Name = "حالة الطالب")]
            [StringLength(10, ErrorMessage = "معرف حالة الطالب لا يمكن أن يتجاوز 10 أحرف")]
            public string? StudentStatusId { get; set; }

            // الصف التالي (bool لتمثيل 0 أو 1)
            [Display(Name = "الترقية للصف التالي")]
            public bool NextGrade { get; set; } // تأكد أنها bool وليست bool?

            // الفصل
            [Display(Name = "الفصل")]
            [StringLength(10, ErrorMessage = "الفصل لا يمكن أن يتجاوز 10 أحرف")]
            public string? Classroom { get; set; }

            // المنطقة
            [Display(Name = "المنطقة")]
            [StringLength(15, ErrorMessage = "معرف المنطقة لا يمكن أن يتجاوز 15 حرفًا")]
            public string? AreaId { get; set; }

            // المدرسة
            [Display(Name = "المدرسة")]
            [StringLength(15, ErrorMessage = "معرف المدرسة لا يمكن أن يتجاوز 15 حرفًا")]
            public string? SchoolId { get; set; }

            // هل يتم إيقاف رسائل SMS (bool)
            [Display(Name = "إيقاف رسائل SMS")]
            public bool StopSms { get; set; } // تأكد أنها bool وليست bool?

            // النوع (ذكر/أنثى) (bool لتمثيل 0 أو 1)
            [Display(Name = "النوع")]
            public bool StudentSex { get; set; } // تأكد أنها bool وليست bool?

            // رقم جواز السفر
            [Display(Name = "رقم جواز السفر")]
            [StringLength(20, ErrorMessage = "رقم جواز السفر لا يمكن أن يتجاوز 20 حرفًا")]
            public string? Passport { get; set; }

            // تاريخ الميلاد (سلسلة نصية)
            [Display(Name = "تاريخ الميلاد")]
            [StringLength(10, ErrorMessage = "تاريخ الميلاد يجب أن يكون 10 أحرف (YYYY-MM-DD)")]
            public string? BirthDateString { get; set; }

            // ملاحظات
            [Display(Name = "ملاحظات")]
            [StringLength(100, ErrorMessage = "الملاحظات لا يمكن أن تتجاوز 100 حرف")]
            public string? Note { get; set; }

            // عام جديد (bool)
            [Display(Name = "عام دراسي جديد")]
            public bool IsNewYear { get; set; } // تأكد أنها bool وليست bool?


    }
} 
