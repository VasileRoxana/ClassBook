using AutoMapper;
using ClassBook.DTOs.StudentDTOs;
using ClassBook.DTOs.UserDTOs;
using ClassBook.Models;
using ClassBook.Repositories.GradeRepository;
using ClassBook.Repositories.StudentRepository;
using ClassBook.Services.StudentService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Controllers
{

    //[Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IStudentService _studentService;

        public HomeController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{studentId}")]
        public IActionResult Index(Guid studentId)
        {
            //pagina principala cu detalii despre student
            var studentHomeDTO = _studentService.GetStudentHome(studentId);

            if (studentHomeDTO != null)
            {                
                return View(studentHomeDTO);
            }

            return NotFound();
        }

    } 
}
