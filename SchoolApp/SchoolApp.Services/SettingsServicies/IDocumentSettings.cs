using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Services.SettingsServicies
{
    public interface IDocumentSettings
    {
        // دالة لرفع الملف
        // المفروض ترجع string بمسار الملف النسبي بعد الرفع
        string UplaodFile(IFormFile file, string foldername);

        // دالة لحذف الملف
        // بتاخد string بمسار الملف النسبي واسم المجلد
        void DeleteFile(string filename, string foldername);

        // ممكن تضيف دوال تانية لو DocumentSettings بتعمل حاجات تانية
    }
}
