using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassBook.Repositories.SubjectRepository;
using ClassBook.Services.StudentService;
using ClassBook.Services.SubjectService;
using Microsoft.AspNetCore.Mvc;

namespace ClassBook.Controllers
{
    public class SubjectController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;

        public SubjectController(IStudentService studentService,
                                ISubjectService subjectService)
        {
            _studentService = studentService;
            _subjectService = subjectService;
        }
        [HttpGet("subject/studentssubjects")]
        //[HttpGet("subject/studentssubjects/{studentId}")]
        public IActionResult StudentsSubjects(Guid studentId)
        {
            //var studentSubjects = _studentService.GetStudentsSubjects(studentId);

            var studentSubjects = _studentService.GetStudentsSubjects(new Guid("6022c911-c800-4457-94f1-66cd952b5fdd"));

            //return View("Views/Student/StudentsSubjects.cshtml", studentSubjects);
            return Ok(studentSubjects);
        }
        [HttpDelete("subject/DeleteSubject/{subjectId}")]
        public IActionResult DeleteSubject(Guid subjectId)
        {
            _subjectService.Delete(subjectId);

            return RedirectToAction("index");
        }

        [HttpGet("Subject/GetSubjectById/{subjectId}")]
        public IActionResult GetSubjectById(Guid subjectId)
        {
            var subjectGetByIdDTO = _subjectService.GetSubjectById(subjectId);

            return View(subjectGetByIdDTO);
        }
    }
}
