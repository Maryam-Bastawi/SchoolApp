using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.BLL.Data.Configurations
{
    public class StudentConfigration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(S => S.Id);
            // CUID (المفتاح الأساسي)
            builder.Property(s => s.Id)
                   .HasColumnName("CUID") // تأكيد اسم العمود
                   .HasMaxLength(40) 
                   .IsRequired(); // المفتاح الأساسي دايماً مطلوب (NOT NULL)

            // CUNM (Name)
            builder.Property(s => s.Name)
                   .HasColumnName("CUNM")
                   .HasMaxLength(65)
                   .IsRequired(); // أو ممكن تشيل .IsRequired(false) لو عايزها nullable بشكل افتراضي

            // CUNM_E (EnglishName)
            builder.Property(s => s.EnglishName)
                   .HasColumnName("CUNM_E")
                   .HasMaxLength(65)
                   .IsRequired(false);

            // TYPEID
            builder.Property(s => s.TypeId)
                   .HasColumnName("TYPEID")
                   .HasMaxLength(20)
                   .IsRequired(false);

            // Email
            builder.Property(s => s.Email)
                   .HasColumnName("Email")
                   .HasMaxLength(100)
                   .IsRequired(false);

            // MObILe1
            builder.Property(s => s.Mobile1)
                   .HasColumnName("Mobile1")
                   .HasMaxLength(15)
                   .IsRequired(false) ;
            builder.HasIndex(s => s.IdNumber)
              .IsUnique();
            // MObILe2
            builder.Property(s => s.Mobile2)
                   .HasColumnName("Mobile2")
                   .HasMaxLength(15)
                   .IsRequired(false);
            builder.HasIndex(s => s.IdNumber)
               .IsUnique();
            // PHON
            builder.Property(s => s.Phone)
                   .HasColumnName("Phone")
                   .HasMaxLength(20)
                   .IsRequired(false);

            // LOCATION
            builder.Property(s => s.Location)
                   .HasColumnName("LOCATION")
                   .HasMaxLength(65)
                   .IsRequired(false);

            // RESPONS
            builder.Property(s => s.Respons)
                   .HasColumnName("RESPONS")
                   .HasMaxLength(65)
                   .IsRequired(false);

            // CREDIT_LIMIT
            builder.Property(s => s.CreditLimit)
                   .HasColumnName("CREDIT_LIMIT")
                   .HasColumnType("int") // تحديد نوع العمود في DB لو محتاج دقة
                   .IsRequired(false);

            // SUSPIND_AC
            builder.Property(s => s.SuspendAccount)
                   .HasColumnName("SUSPIND_AC")
                   .HasColumnType("tinyint") // NUMBER(1,0) غالباً بيكون tinyint أو bit
                   .IsRequired();

            // IDNUM
            builder.Property(s => s.IdNumber)
                   .HasColumnName("IDNUM")
                   .HasMaxLength(11)
                   .IsRequired(false);
            builder.HasIndex(s => s.IdNumber)
             .IsUnique();
            // IDISSIODATE (نص، ممكن تحوله لتاريخ لو قررت استخدام DateTime)
            builder.Property(s => s.IdIssueDateString)
                   .HasColumnName("IDISSIODATE")
                   .HasMaxLength(10)
                   .IsRequired(false);
            // لو قررت تستخدم DateTime?، هتكون كده:
            // builder.Property(s => s.IdIssueDate)
            //        .HasColumnName("IDISSIODATE")
            //        .HasColumnType("date") // أو datetime2 حسب دقة التاريخ في DB
            //        .IsRequired(false);


            // IDENDDATE
            builder.Property(s => s.IdEndDateString)
                   .HasColumnName("IDENDDATE")
                   .HasMaxLength(10)
                   .IsRequired(false);

            // IDPLACE
            builder.Property(s => s.IdPlace)
                   .HasColumnName("IDPLACE")
                   .HasMaxLength(50)
                   .IsRequired(false);

            // NATID
            builder.Property(s => s.NationalId)
                   .HasColumnName("NATID")
                   .HasMaxLength(65)
                   .IsRequired(false);

            builder.Property(s => s.ImgName)
                       .HasColumnName("ImgName")
                       .HasColumnType("nvarchar(max)") // استخدم nvarchar(max) لتخزين Base64 string
                       .IsRequired(false);

            // VECHID
            builder.Property(s => s.VehicleId)
                   .HasColumnName("VECHID")
                   .HasMaxLength(10)
                   .IsRequired(false);

            // STAGESID
            builder.Property(s => s.StagesId)
                   .HasColumnName("STAGESID")
                   .HasMaxLength(10)
                   .IsRequired(false);

            // GRADESID
            builder.Property(s => s.GradesId)
                   .HasColumnName("GRADESID")
                   .HasMaxLength(10)
                   .IsRequired(false);

            // STUDENTSTATUSID
            builder.Property(s => s.StudentStatusId)
                   .HasColumnName("STUDENTSTATUSID")
                   .HasMaxLength(10)
                   .IsRequired(false);

            // NEXTGRADE
            builder.Property(s => s.NextGrade)
                   .HasColumnName("NEXTGRADE")
                   .HasColumnType("tinyint")
                   .IsRequired();

            // CLASSROOM
            builder.Property(s => s.Classroom)
                   .HasColumnName("CLASSROOM")
                   .HasMaxLength(10)
                   .IsRequired(false);

            // AREAID
            builder.Property(s => s.AreaId)
                   .HasColumnName("AREAID")
                   .HasMaxLength(15)
                   .IsRequired(false);

            // SCHOOLID
            builder.Property(s => s.SchoolId)
                   .HasColumnName("SCHOOLID")
                   .HasMaxLength(15)
                   .IsRequired(false);

            // STOPSMS
            builder.Property(s => s.StopSms)
                   .HasColumnName("STOPSMS")
                   .IsRequired();

            // STUDSEX
            builder.Property(s => s.StudentSex)
                   .HasColumnName("STUDSEX")
                   .HasColumnType("tinyint")
                   .IsRequired();

            // DEPART
            builder.Property(s => s.Depart)
                   .HasColumnName("DEPART")
                   .HasColumnType("tinyint")
                   .IsRequired();

            // STUDIDNUM
            builder.Property(s => s.StudentIdNumber)
                   .HasColumnName("STUDIDNUM")
                   .HasMaxLength(11)
                   .IsRequired(false);

            // SUSPINDDATE
            builder.Property(s => s.SuspendDateString)
                   .HasColumnName("SUSPINDDATE")
                   .HasMaxLength(10)
                   .IsRequired(false);

            // ISGRADUATE
            builder.Property(s => s.IsGraduate)
                   .HasColumnName("ISGRADUATE")
                   .HasColumnType("tinyint")
                   .IsRequired();

            // PASSPORT
            builder.Property(s => s.Passport)
                   .HasColumnName("PASSPORT")
                   .HasMaxLength(20)
                   .IsRequired(false);
            builder.HasIndex(s => s.Passport)
            .IsUnique();
            // BIRTHDATE
            builder.Property(s => s.BirthDateString)
                   .HasColumnName("BIRTHDATE")
                   .HasMaxLength(10)
                   .IsRequired(false);

            // NOTE
            builder.Property(s => s.Note)
                   .HasColumnName("NOTE")
                   .HasMaxLength(100)
                   .IsRequired(false);

            // ISNEWYEAR
            builder.Property(s => s.IsNewYear)
                   .HasColumnName("ISNEWYEAR")
                   .HasColumnType("tinyint")
                   .IsRequired();


        }
    }
}
