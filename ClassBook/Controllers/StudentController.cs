using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ClassBook.DTOs.StudentDTOs;
using ClassBook.Models;
using ClassBook.Repositories.StudentRepository;
using ClassBook.Services.AccountService;
using ClassBook.Services.StudentService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace ClassBook.Controllers
{
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IAccountService _accountService;
        private readonly SignInManager<AppUser> _signInManager;

        private readonly ILogger _logger;
        public StudentController(IStudentService studentService,
                                 IAccountService accountService,
                                 SignInManager<AppUser> signInManager)
        {
            _studentService = studentService;
            _accountService = accountService;
            _signInManager = signInManager;
        }

        [HttpGet("Edit")]
        public IActionResult Edit()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var userId = new Guid(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);

                var studentId = _accountService.GetStudentId(userId);

                var studentEditDTO = _studentService.GetStudentToEdit(studentId);

                return View(studentEditDTO);
            }

            throw new NullReferenceException("User not logged in");
        }

        [HttpPut("Edit/{studentId}")]
        public IActionResult Edit(StudentEditDTO studentEditDTO) 
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid student object sent from client");
                return BadRequest("Invalid model object");
            }

            var result = _studentService.UpdateStudent(studentEditDTO);

            if (result)
            {
                return RedirectToAction("index", "home", new { studentId = studentEditDTO.Id});
            }
            else
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
