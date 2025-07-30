using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.BLL.ModelViews;
using SchoolApp.BLL.Services.Contract;
using SchoolApp.DAL.Entities;
using SchoolApp.Services;

namespace SchoolApp.Controllers
{
    public class StudentsController : Controller
    {
        // GET: StudentsController
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentsController> _logger;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StudentsController(IStudentService studentService, ILogger<StudentsController> logger , IMapper mapper , IWebHostEnvironment webHostEnvironment)
        {
            _studentService = studentService;
            _logger = logger;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;

        }

        // GET: Students
        public async Task<IActionResult> Index(string searchinput)
        {
            // تخزين مدخل البحث الحالي لملء مربع البحث مسبقًا في الواجهة
            ViewBag.CurrentSearchInput = searchinput;

            try
            {
                IReadOnlyList<StudentDto> studentDtos = await _studentService.GetbyNameAsync(searchinput);

                // تمرير DTOs مباشرة إلى الواجهة
                return View(studentDtos);
            }
            catch (DatabaseOperationException ex)
            {
                _logger.LogError(ex, "فشل في استرداد الطلاب من قاعدة البيانات بمدخل البحث: {SearchInput}", searchinput);
                TempData["ErrorMessage"] = "حدث خطأ في قاعدة البيانات أثناء جلب الطلاب.";
                return View(new List<StudentDto>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "حدث خطأ غير متوقع أثناء استرداد الطلاب بمدخل البحث: {SearchInput}", searchinput);
                TempData["ErrorMessage"] = "حدث خطأ غير متوقع أثناء جلب الطلاب.";
                return View(new List<StudentDto>());
            }
        }
        // GET: StudentsController/Create (هذا هو الأكشن الذي انتهينا منه سابقًا)
        public ActionResult Create()
        {
            return View();
        }


        // POST: StudentsController/Create
        // هذا الأكشن سيتلقى البيانات من النموذج لإنشاء طالب جديد
        [HttpPost] // تحدد أن هذا الأكشن يستقبل طلبات POST
        [ValidateAntiForgeryToken] // حماية ضد هجمات تزوير الطلبات عبر المواقع (CSRF)
        public async Task<IActionResult> Create(CreateStudentDto createDto) // <--- يقبل CreateStudentDto
        {

            if (!ModelState.IsValid)
                return View(createDto);

            try
            {
                var createdStudentDto = await _studentService.CreateStudentAsync(createDto);

                if (createdStudentDto != null)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "فشل إنشاء الطالب. يرجى المحاولة مرة أخرى.");
            }
            catch (DatabaseOperationException ex) when (ex.Message.Contains("الهوية"))
            {
                ModelState.AddModelError(nameof(createDto.IdNumber), ex.Message);
            }
            catch (DatabaseOperationException ex)
            {
                ModelState.AddModelError("", $"خطأ في قاعدة البيانات: {ex.Message}");
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("", $"حدث خطأ أثناء تحميل الصورة: {ex.Message}");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "حدث خطأ غير متوقع أثناء إنشاء الطالب.");
            }

            return View(createDto);
        }


        // ... (بقية أكشنات الكنترولر الأخرى) ...


            // ... (بقية أكشنات الكنترولر: Details, Create, Edit, Delete) ...


            // GET: StudentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    


        // GET: StudentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
