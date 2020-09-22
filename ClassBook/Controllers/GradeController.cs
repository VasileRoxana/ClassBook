using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ClassBook.DTOs.GradeDTOs;
using ClassBook.Services.GradeService;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ClassBook.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;
        private readonly IMapper _mapper;
        public GradeController(IGradeService gradeService,
                                IMapper mapper)
        {
            _gradeService = gradeService;
            _mapper = mapper;
        }

        [HttpGet("Grade/GetSubjectGrades/{subjectId}")]
        public IActionResult GetSubjectGrades(Guid subjectId)
        {
            var grades = _gradeService.GetGradesBySubjectId(subjectId);

            return View(grades);
        }
        [HttpPatch("Grade/UpdateGrade/{gradeId}")]  //POSTMAN
        public IActionResult UpdateGrade(Guid gradeId, [FromBody] IDictionary<string, string> properties)
        {

            _gradeService.UpdateGrade(gradeId, properties);        

            return Ok();
        }

        [HttpGet("Grade/GetGradesGroupedBySubjectId")]
        public IActionResult GetGradesGroupedBySubjectId()
        {
            var userId = new Guid(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);

            var grades = _gradeService.GetGradesGroupedBySubjectId(userId);

            return View(grades);

        }
    }
}
