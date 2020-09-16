using AutoMapper;
using ClassBook.DTOs.StudentDTOs;
using ClassBook.Models;
using ClassBook.Repositories.StudentRepository;
using ClassBook.Repositories.SubjectGradesRepository;
using ClassBook.Repositories.SubjectRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly ISubjectGradesRepository _subjectGradesRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public StudentService(ISubjectGradesRepository subjectGradesRepository,
                                IStudentRepository studentRepository,
                                ISubjectRepository subjectRepository,
                                IMapper mapper)
        {
            _subjectGradesRepository = subjectGradesRepository;
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public StudentHomeDTO GetStudentHome(Guid studentId)
        {
            var student = _studentRepository.GetStudent(studentId);

            if (student != null)
            {
                var studentHomeDTO = _mapper.Map<StudentHomeDTO>(student);

                if(studentHomeDTO != null)
                {
                    return studentHomeDTO;
                }
            }

            return null;
        }

        public List<Subject> GetStudentsSubjects(Guid studentId)
        {
            var subjectGrades = _subjectGradesRepository.GetSubjectGradesByStudentId(studentId);

            var studentSubjects = subjectGrades.Where(d => d.StudentId == studentId)
                            .Select(d => d.Subject)
                            .ToList();

            return studentSubjects;                       
        }

        public StudentEditDTO GetStudentToEdit(Guid studentId)
        {
            // VALIDATIONS 
            var student = _studentRepository.GetStudent(studentId);

            StudentEditDTO studentEditDTO = _mapper.Map<StudentEditDTO>(student);

            return studentEditDTO;
        }

        public bool UpdateStudent(StudentEditDTO studentEditDTO)
        {
            try
            {
                if (studentEditDTO == null)
                {
                    _logger.LogError("Student object sent from client is null");
                    return false;
                }

                //iau studentul din bd cu id ul parametru
                var student = _studentRepository.GetStudent(studentEditDTO.Id);

                //mapez dto-ul cu informatiile adaugate in form pe studentul luat din bd
                _mapper.Map(studentEditDTO, student);

                //update student din bd cu metoda din repository
                _studentRepository.Update(student);

                //save student din repository
                _studentRepository.Save();

                return true; //to return the 200response

            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong inside the UpdateStudent action: { e.Message }");
                return false;
            }
        }
    }
}
