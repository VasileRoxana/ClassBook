using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassBook.DTOs.StudentDTOs;
using ClassBook.Repositories.StudentRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClassBook.Controllers
{
    public class StudentController : Controller
    {
        IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public StudentController(IStudentRepository studentRepository,
             IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet("student/edit/{studentId}")]
        public IActionResult Edit(Guid studentId)
        {
            var student = _studentRepository.GetStudent(studentId);

            StudentEditDTO studentEditDTO = _mapper.Map<StudentEditDTO>(student);

            return View(studentEditDTO);
        }

        [HttpPut("student/edit/{studentId}")] //DE MODIFICAT SA IA DIN BODY DTO NU DIN URL din motive de securitate
        public IActionResult Edit(Guid studentId, StudentEditDTO studentEditDTO)
        {
            try
            {
                if(studentEditDTO == null)
                {
                    _logger.LogError("Student object sent from client is null");
                    return BadRequest("Student object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid student object sent from client");
                    return BadRequest("Invalid model object");
                }

                //iau studentul din bd cu id ul parametru
                var student = _studentRepository.GetStudent(studentId);

                //mapez dto-ul cu informatiile adaugate in form pe studentul luat din bd
                _mapper.Map(studentEditDTO, student);

                //update student din bd cu metoda din repository
                _studentRepository.Update(student);

                //save student din repository
                _studentRepository.Save();

                return Ok(); //to return the 200response

            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong inside the EditStudent action: { e.Message }");
                return StatusCode(500, "Internal server error");
            }


            return View();
        }
    }
}
