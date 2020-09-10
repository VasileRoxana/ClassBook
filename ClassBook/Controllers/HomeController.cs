using AutoMapper;
using ClassBook.DTOs.StudentDTOs;
using ClassBook.DTOs.UserDTOs;
using ClassBook.Models;
using ClassBook.Repositories.GradeRepository;
using ClassBook.Repositories.StudentRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;

        public HomeController(IStudentRepository studentRepository,
                               IGradeRepository gradeRepository,
                               IMapper mapper)
        {
            _studentRepository = studentRepository;
            _gradeRepository = gradeRepository;
            _mapper = mapper;  
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{userId}")]
        public ActionResult<StudentHomeDTO> Index(Guid userId)
        {
            //pagina principala cu detalii despre student
            var student = _studentRepository.GetStudent(studentId);

            if (student != null)
            {                
                return View(_mapper.Map<StudentHomeDTO>(student));
            }

            return NotFound();
        }

    } 
}
