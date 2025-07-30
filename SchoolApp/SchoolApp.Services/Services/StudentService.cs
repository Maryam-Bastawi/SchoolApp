
using AutoMapper;
using Microsoft.EntityFrameworkCore.Migrations;
using SchoolApp.BLL.Migrations;
using SchoolApp.BLL.ModelViews;
using SchoolApp.BLL.Services.Contract;
using SchoolApp.BLL.UnitOfWork;
using SchoolApp.BLL.UnitOfWork.UnitOfWork;
using SchoolApp.DAL.Entities;
using SchoolApp.DAL.Interfaces;
using SchoolApp.Services.SettingsServicies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Services.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDocumentSettings _documentSettings;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper, IDocumentSettings documentSettings)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _documentSettings = documentSettings; // <--- هنا التغيير

        }
        // --- إنشاء طالب جديد (Create) ---
        public async Task<StudentDto?> CreateStudentAsync(CreateStudentDto createDto)
        
        {
            string? uploadedImagePath = null;

            try
            {
                // 1. التحقق من تكرار رقم الهوية قبل أي عملية
                if (await _unitOfWork.StudentRepository.AnyByIdNumberAsync(createDto.IdNumber))
                {
                    throw new DatabaseOperationException("رقم الهوية مستخدم بالفعل لطالب آخر.");
                }

                // 2. تحميل الصورة إذا وُجدت
                if (createDto.StudentImage != null && createDto.StudentImage.Length > 0)
                {
                    uploadedImagePath = _documentSettings.UplaodFile(createDto.StudentImage, "img");
                    createDto.ImgName = uploadedImagePath;
                }

                // 3. تحويل DTO إلى كيان Student
                var student = _mapper.Map<Student>(createDto);
                student.Id = Guid.NewGuid().ToString();

                // 4. حفظ الطالب في قاعدة البيانات
                await _unitOfWork.StudentRepository.AddAsync(student);
                var result = await _unitOfWork.CompleteAsync();

                // 5. التحقق من نجاح الحفظ
                if (result <= 0)
                {
                    if (!string.IsNullOrEmpty(uploadedImagePath))
                    {
                        _documentSettings.DeleteFile(uploadedImagePath, "img");
                    }

                    throw new DatabaseOperationException("فشل إنشاء الطالب. لم يتم إضافة أي بيانات إلى قاعدة البيانات.");
                }

                // 6. إعادة الطالب الناتج على هيئة DTO
                return _mapper.Map<StudentDto>(student);
            }
            catch (ApplicationException ex)
            {
                // خطأ خاص بتحميل الصورة
                throw new ApplicationException("فشل تحميل ملف الصورة أثناء إنشاء الطالب.", ex);
            }
            catch (Exception ex)
            {
                // حذف الصورة عند حدوث خطأ غير متوقع
                if (!string.IsNullOrEmpty(uploadedImagePath))
                {
                    _documentSettings.DeleteFile(uploadedImagePath, "img");
                }

                throw new DatabaseOperationException("حدث خطأ غير متوقع أثناء إنشاء الطالب.", ex);
            }
        }
        public async Task<StudentDto?> GetStudentByIdAsync(string studentById)
        {
            try
            {
                var student = await _unitOfWork.Repository<Student, string>().GetByIdAsync(studentById);
                if (student == null)
                {
                    return null;
                }
                return _mapper.Map<StudentDto>(student);
            }
            catch (Exception ex)
            {
                throw new DatabaseOperationException($"فشل استرجاع الطالب بالرقم التعريفي {studentById}.", ex);
            }
        }

        // --- جلب جميع الطلاب (GetAll) ---
        public async Task<IReadOnlyList<StudentDto>> GetAllStudentsAsync()
        {
            try
            {
                var students = await _unitOfWork.Repository<Student, string>().GetAllAsync();

                // إرجاع قائمة فارغة بدلاً من null إذا لم يتم العثور على طلاب
                if (students == null || !students.Any())
                {
                    return new List<StudentDto>().AsReadOnly();
                }

                return _mapper.Map<IReadOnlyList<StudentDto>>(students);
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, "فشل استرجاع جميع الطلاب من طبقة الخدمة.");
                throw new DatabaseOperationException("فشل استرجاع جميع الطلاب من طبقة الخدمة.", ex);
            }
        }

        // --- جلب الطلاب بالاسم (GetbyName) ---
        public async Task<IReadOnlyList<StudentDto>> GetbyNameAsync(string name)
        {
            try
            {
                // هذا يفترض أن GenericRepository<Student, string> لديه GetByNameAsync
                // أو يمكنك استخدام _unitOfWork.StudentRepository.GetByNameAsync(name); إذا كان StudentRepository محددًا.
                var students = await _unitOfWork.StudentRepository.GetbyNameAsync(name);

                if (students == null || !students.Any())
                {
                    return new List<StudentDto>().AsReadOnly();
                }

                return _mapper.Map<IReadOnlyList<StudentDto>>(students);
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, "فشل استرجاع الطلاب بالاسم {Name} من طبقة الخدمة.", name);
                throw new DatabaseOperationException($"فشل استرجاع الطلاب بالاسم {name} من طبقة الخدمة.", ex);
            }
        }

        // --- جلب جميع الطلاب بالمواصفات (GetAll With Spec) ---
        public async Task<IReadOnlyList<StudentDto>> GetAllStudentsWithSpecAsync(ISpecifications<Student, string> spec)
        {
            try
            {
                var studentsSpec = await _unitOfWork.Repository<Student, string>().GetAllWithSpecAsync(spec);
                if (studentsSpec == null || !studentsSpec.Any())
                {
                    return new List<StudentDto>().AsReadOnly();
                }
                return _mapper.Map<IReadOnlyList<StudentDto>>(studentsSpec);
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, "فشل استرجاع جميع الطلاب بالمواصفات.");
                throw new DatabaseOperationException("فشل استرجاع جميع الطلاب بالمواصفات.", ex);
            }
        }

        // --- جلب عدد الطلاب بالمواصفات (Get Count With Spec) ---
        public async Task<int> GetStudentCountAsync(ISpecifications<Student, string> spec)
        {
            try
            {
                var studentCount = await _unitOfWork.Repository<Student, string>().GetCountWithAsync(spec);
                return studentCount;
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, "فشل استرجاع عدد الطلاب بالمواصفات.");
                throw new DatabaseOperationException("فشل استرجاع عدد الطلاب بالمواصفات.", ex);
            }
        }

        // --- تحديث طالب موجود (Update) ---
        public async Task<StudentDto?> UpdateStudentAsync(string studentById, UpdateStudentDto updateDto)
        {
            // متغير لتخزين المسار الجديد للصورة اللي هيتم رفعها (لو فيه).
            // هنستخدمه لو حصل أي خطأ في الحفظ بعد الرفع عشان نحذف الملف اليتيم.
            string? uploadedImagePath = null;

            try
            {
                // 1. جلب الطالب الحالي من قاعدة البيانات.
                var existingStudent = await _unitOfWork.Repository<Student, string>().GetByIdAsync(studentById);

                if (existingStudent == null)
                {
                    return null; // الطالب مش موجود.
                }

                // 2. التعامل مع الصورة (رفع جديد، حذف قديم)
                // لو المستخدم رفع صورة جديدة.
                if (updateDto.StudentImage != null && updateDto.StudentImage.Length > 0)
                {
                    // لو فيه صورة قديمة مربوطة بالطالب ده، نحذفها الأول.
                    if (!string.IsNullOrEmpty(existingStudent.ImgName))
                    {
                        _documentSettings.DeleteFile(existingStudent.ImgName, "img");
                    }

                    // رفع الصورة الجديدة وتخزين المسار بتاعها.
                    uploadedImagePath = _documentSettings.UplaodFile(updateDto.StudentImage, "img");
                    // تعيين المسار الجديد للـ ImgName في الـ DTO عشان الـ AutoMapper ياخده.
                    updateDto.ImgName = uploadedImagePath;
                }
                // لو المستخدم طلب حذف الصورة الحالية ومرفعش صورة جديدة.
                else if (updateDto.RemoveExistingImage && !string.IsNullOrEmpty(existingStudent.ImgName))
                {
                    // حذف الصورة القديمة من السيرفر.
                    _documentSettings.DeleteFile(existingStudent.ImgName, "img");
                    // مسح المسار من ImgName في الـ DTO عشان يتسيف null في الداتا بيز.
                    updateDto.ImgName = null;
                }
                // لو مفيش صورة جديدة اترفعت وكمان مفيش طلب لحذف الصورة القديمة،
                // يبقى كده ImgName في الـ updateDto هيفضل زي ما هو (قيمته اللي كانت فيه من الـ GET request).
                // أو لو الـ DTO تم إنشاؤه بدون ImgName، فـ AutoMapper هيسيب existingStudent.ImgName زي ما هو،
                // وده هو السلوك الصح لو المستخدم محددش أي تغيير للصورة.

                // 3. تحديث باقي خصائص الطالب من الـ DTO للـ Entity.
                // الـ AutoMapper هيعمل Map لكل الخصائص المشتركة بين updateDto و existingStudent.
                // بما فيهم ImgName بعد ما عدلناه في الخطوة اللي فاتت (لو فيه تغيير).
                _mapper.Map(updateDto, existingStudent);

                // 4. تحديث تاريخ آخر تعديل.

                // 5. إبلاغ الـ UnitOfWork إن الـ Entity ده اتعدل، وحفظ التغييرات في الداتا بيز.
                _unitOfWork.Repository<Student, string>().UpdateAsync(existingStudent);
                var result = await _unitOfWork.CompleteAsync();

                // 6. التحقق من نجاح عملية الحفظ في الداتا بيز.
                if (result <= 0)
                {
                    // لو الحفظ فشل، نحذف الصورة الجديدة اللي اترفعت عشان متفضلش ملفات يتيمة.
                    if (!string.IsNullOrEmpty(uploadedImagePath))
                    {
                        _documentSettings.DeleteFile(uploadedImagePath, "img");
                    }
                    throw new DatabaseOperationException("فشل تحديث الطالب. لم يتم إضافة أي تغييرات إلى قاعدة البيانات.");
                }

                // 7. لو كل حاجة نجحت، نحول الـ Entity بتاع الطالب لـ DTO ونرجعه.
                return _mapper.Map<StudentDto>(existingStudent);
            }
            // معالجة الأخطاء.
            catch (ApplicationException ex)
            {
                // _logger.LogError(ex, "فشل تحميل ملف الصورة أثناء تحديث الطالب.");
                // لو الرفع فشل، ممكن تحذف الصورة الجديدة لو كانت اترفعت (قبل الـ catch).
                if (!string.IsNullOrEmpty(uploadedImagePath))
                {
                    _documentSettings.DeleteFile(uploadedImagePath, "img");
                }
                throw new ApplicationException("فشل تحميل ملف الصورة أثناء تحديث الطالب.", ex);
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, "حدث خطأ غير متوقع أثناء تحديث الطالب بالمعرف {StudentId}.", studentById);
                // لو حصل أي خطأ تاني غير متوقع.
                if (!string.IsNullOrEmpty(uploadedImagePath))
                {
                    _documentSettings.DeleteFile(uploadedImagePath, "img");
                }
                throw new DatabaseOperationException($"حدث خطأ غير متوقع أثناء تحديث الطالب بالمعرف {studentById}.", ex);
            }
        }

        // --- حذف طالب (Delete) ---


           public async Task<bool> DeleteStudentAsync(string studentById)
           {
            try
            {
                // 1. البحث عن الطالب المراد حذفه في قاعدة البيانات
                var studentToDelete = await _unitOfWork.Repository<Student, string>().GetByIdAsync(studentById);

                // إذا لم يتم العثور على الطالب، نرجع false لأنه لا يوجد ما يحذف
                if (studentToDelete == null)
                {
                    return false;
                }

                // 2. حذف ملف الصورة المرتبط بالطالب من السيرفر (إذا كان موجودًا)
                // نتحقق مما إذا كان حقل 'ImgName' ليس فارغًا أو null
                if (!string.IsNullOrEmpty(studentToDelete.ImgName))
                {
                    // استخدام DocumentSettings لحذف الصورة، مع تحديد اسم المجلد "StudentImage"
                    _documentSettings.DeleteFile(studentToDelete.ImgName, "img");
                }

                // 3. وضع علامة على كيان الطالب للحذف من قاعدة البيانات
                _unitOfWork.Repository<Student, string>().DeleteAsync(studentToDelete);

                // 4. حفظ التغييرات في قاعدة البيانات
                // _unitOfWork.CompleteAsync() سيعيد عدد الصفوف المتأثرة بعمليات الحفظ
                var result = await _unitOfWork.CompleteAsync();

                // 5. التحقق من نجاح عملية الحذف من قاعدة البيانات
                if (result <= 0)
                {
                    // إذا لم يتم حذف أي صف (result <= 0)، فهذا يعني أن عملية الحذف فشلت
                    // _logger.LogError("فشل حذف الطالب. لم تتم إزالة أي صفوف من قاعدة البيانات."); // يمكن تفعيل هذا للـ Logging
                    throw new DatabaseOperationException("فشل حذف الطالب. لم تتم إزالة أي صفوف من قاعدة البيانات.");
                }

                // إذا نجحت جميع الخطوات، نرجع true
                return true;
            }
            catch (Exception ex)
            {
                // 6. التعامل مع أي أخطاء غير متوقعة تحدث أثناء عملية الحذف
                // _logger.LogError(ex, "حدث خطأ غير متوقع أثناء حذف الطالب بالمعرف {StudentId}.", studentById); // يمكن تفعيل هذا للـ Logging
                throw new DatabaseOperationException($"حدث خطأ غير متوقع أثناء حذف الطالب بالمعرف {studentById}.", ex);
            }
        }
    }
}