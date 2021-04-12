using System;
using System.Collections.Generic;
using AutoMapper;
using ClassBook.Services.GradeService;
using Microsoft.AspNetCore.Mvc;

namespace ClassBook.Controllers
{
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;
        private readonly IMapper _mapper;
        public GradeController(IGradeService gradeService,
                                IMapper mapper)
        {
            _gradeService = gradeService;
            _mapper = mapper;
        }

        //[HttpGet("Grade/GetSubjectGrades/{subjectId}")]
        //public IActionResult GetSubjectGrades(Guid subjectId)
        //{
        //    var grades = _gradeService.GetGradesBySubjectId(subjectId);

        //    return View(grades);
        //}
        //[HttpPatch("Grade/UpdateGrade/{gradeId}")]  //POSTMAN
        //public IActionResult UpdateGrade(Guid gradeId, [FromBody] IDictionary<string, string> properties)
        //{

        //    _gradeService.UpdateGrade(gradeId, properties);        

        //    return Ok();
        //}

        [HttpGet("Grade/GetGradesGroupedBySubjectId")]
        public IActionResult GetGradesGroupedBySubjectId()
        {
            //var userId = new Guid(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);

            var grades = _gradeService.GetGradesGroupedBySubjectId(new Guid("afb720ac-aaf5-438b-5037-08d8501694c0"));

            return Ok(grades); 
        }
    }
}
