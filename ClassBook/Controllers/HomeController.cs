using ClassBook.Models;
using ClassBook.Repositories.AccountRepository;
using ClassBook.Services.AccountService;
using ClassBook.Services.StudentService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace ClassBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IAccountService _accountService;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(IStudentService studentService,
                              IAccountService accountService,
                              SignInManager<AppUser> signInManager)
        {
            _studentService = studentService;
            _accountService = accountService;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var userId = new Guid(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);

                var studentId2 = _accountService.GetStudentId(userId);

                var studentHomeDTO = _studentService.GetStudentHome(studentId2);

                if (studentHomeDTO != null)
                {
                    return View(studentHomeDTO);
                }
            }

            return View();
        }
    } 
}
