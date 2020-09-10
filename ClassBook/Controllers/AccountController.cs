using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassBook.DTOs.UserDTOs;
using ClassBook.Models;
using ClassBook.Repositories.StudentRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ClassBook.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 IStudentRepository studentRepository,
                                 IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDTO userRegisterDTO)
        {
            if (ModelState.IsValid)
            {
                var student = new Student { Id = Guid.NewGuid(), DateOfBirth = userRegisterDTO.Student.DateOfBirth, Name = userRegisterDTO.Student.Name };
                _studentRepository.Add(student);

                var user = new AppUser { UserName = userRegisterDTO.Email, Email = userRegisterDTO.Email, StudentId = student.Id };
                var result = await _userManager.CreateAsync(user, userRegisterDTO.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", student.Id);
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description); 
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<UserLoginDTO>(userLoginDTO);
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                var user = await _userManager.FindByEmailAsync(model.Email);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", new RouteValueDictionary(
                        new { controller = "home", action = "index", studentId = user.StudentId }));
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}
