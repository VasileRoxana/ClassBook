using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassBook.Repositories.SubjectRepository;
using ClassBook.Services.StudentService;
using Microsoft.AspNetCore.Mvc;

namespace ClassBook.Controllers
{
    public class SubjectController : Controller
    {
        private readonly IStudentService _studentServices;

        public SubjectController(IStudentService studentService)
        {
            _studentServices = studentService;
        }
        [HttpGet]
        public IActionResult StudentsSubjects(Guid studentId)
        {


            return View("Views/Student/StudentsSubjects.cshtml");
        }
    }
}
