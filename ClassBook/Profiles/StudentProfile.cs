﻿using AutoMapper;
using ClassBook.DTOs.StudentDTOs;
using ClassBook.DTOs.UserDTOs;
using ClassBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentHomeDTO>().ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Id));
            CreateMap<AppUser, UserLoginDTO>();
            CreateMap<StudentEditDTO, Student>();
            CreateMap<Student, StudentEditDTO>();
        }
    }
}
