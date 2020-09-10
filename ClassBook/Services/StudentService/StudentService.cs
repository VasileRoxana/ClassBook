using ClassBook.Models;
using ClassBook.Repositories.StudentRepository;
using ClassBook.Repositories.SubjectGradesRepository;
using ClassBook.Repositories.SubjectRepository;
using Microsoft.EntityFrameworkCore;
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
        public StudentService(ISubjectGradesRepository subjectGradesRepository,
                                IStudentRepository studentRepository,
                                ISubjectRepository subjectRepository)
        {
            _subjectGradesRepository = subjectGradesRepository;
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
        }
        public List<Subject> GetStudentsSubjects(Guid studentId)
        {
            var subjectGrades = _subjectGradesRepository.GetSubjectGradesByStudentId(studentId);

            var studentSubjects = subjectGrades.Where(d => d.StudentId == studentId)
                            .Select(d => d.Subject)
                            .ToList();

            return studentSubjects;                       
        }
    }
}
