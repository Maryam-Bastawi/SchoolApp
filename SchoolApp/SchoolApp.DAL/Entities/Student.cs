using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.DAL.Entities
{
    public class Student : BaseEntity<string>
    {

        // ده بيحدد إن CUID هو المفتاح الأساسي.
        // بما إنه بيرث من BaseEntity<string>، بنعمل override للخاصية Id
        public string Name { get; set; } // تم تغيير CUNM لـ Name عشان يبقى أوضح
        public string? EnglishName { get; set; } // تم تغيير CUNM_E لـ EnglishName
        public string? TypeId { get; set; }
        public string? Email { get; set; }
        public string? Mobile1 { get; set; }
        public string? Mobile2 { get; set; }
        public string? Phone { get; set; }
        public string? Location { get; set; }
        public string? Respons { get; set; } // ممكن يكون المسؤول أو الجهة المسؤولة
        public int? CreditLimit { get; set; } // تم تغييرها لـ int? بناءً على طلبك
        public bool SuspendAccount { get; set; } // int(1,0) بيتحول لـ boo
        public string? IdNumber { get; set; } // رقم الهوية
                                              // بما إنه String(10)، ممكن تخليه string? ولو عايز تتعامل معاه كتاريخ هتحتاج تحويل يدوي
        public string? IdIssueDateString { get; set; }
        public string? IdEndDateString { get; set; }
        public string? IdPlace { get; set; }
        public string? NationalId { get; set; } // الرقم القومي أو المعرف الوطني
                                                // بما إن STUDIMG ليس له نوع محدد، افترضت أنه BLOB أو ما شابه
        public string? ImgName { get; set; }
        public string? VehicleId { get; set; }
        public string? StagesId { get; set; } // معرف المراحل الدراسية
        public string? GradesId { get; set; } // معرف الدرجات/الصفوف
        public string? StudentStatusId { get; set; }
        public bool NextGrade { get; set; } // int(1,0) بيتحول لـ bool
        public string? Classroom { get; set; }
        public string? AreaId { get; set; }
        public string? SchoolId { get; set; }
        public bool StopSms { get; set; } // ممكن يكون flag لوقف الرسائل
        public bool StudentSex { get; set; } // int(1,0) بيتحول لـ bool (ممكن يكون 0 للمذكر 1 للمؤنث مثلاً)
        public bool Depart { get; set; } // int(1,0) بيتحول لـ bool
        public string? StudentIdNumber { get; set; } // ممكن يكون رقم قيد الطالب أو رقم تاني
        public string? SuspendDateString { get; set; }
        public bool IsGraduate { get; set; } // int(1,0) بيتحول لـ bool
        public string? Passport { get; set; }
        public string? BirthDateString { get; set; }
        public string? Note { get; set; }
        public bool IsNewYear { get; set; } // int(1,0) بيتحول لـ bool
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }

    }

