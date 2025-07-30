using AutoMapper;
using Microsoft.Extensions.Configuration;
using SchoolApp.BLL.ModelViews;
using SchoolApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolApp.BLL.Mapping
{
    public class StudentProfile : Profile
    {
       

        public StudentProfile()
        {
            

            CreateMap<StudentDto, Student>().ReverseMap();
            CreateMap<CreateStudentDto, Student>().ReverseMap();
            CreateMap<UpdateStudentDto, Student>().ReverseMap();
        }
    }
}
