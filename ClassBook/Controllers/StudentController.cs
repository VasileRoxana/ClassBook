using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassBook.DTOs.StudentDTOs;
using ClassBook.Repositories.StudentRepository;
using ClassBook.Services.StudentService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClassBook.Controllers
{
    [Route("[controller]")]
    public class StudentController : Controller
    {
        IStudentService _studentService;
        
        private readonly ILogger _logger;
        public StudentController(IStudentService studentService,
                                ILogger logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        [HttpGet("Edit/{studentId}")]
        public IActionResult Edit(Guid studentId)
        {
            var studentEditDTO = _studentService.GetStudentToEdit(studentId);

            return View(studentEditDTO);
        }

        [HttpPut("Edit/{studentId}")]
        public IActionResult Edit(StudentEditDTO studentEditDTO) //DE STERS ID UL
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid student object sent from client");
                return BadRequest("Invalid model object");
            }

            var result = _studentService.UpdateStudent(studentEditDTO);

            if (result)
            {
                return RedirectToAction("index", "home", new { studentId = studentEditDTO.Id });
            }
            else
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
