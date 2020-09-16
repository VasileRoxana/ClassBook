using ClassBook.DTOs.StudentDTOs;
using ClassBook.Models;
using ClassBook.Repositories.SubjectGradesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Services.StudentService
{
    public interface IStudentService 
    {
        List<Subject> GetStudentsSubjects(Guid studentId);
        StudentEditDTO GetStudentToEdit(Guid studentId);
        StudentHomeDTO GetStudentHome(Guid studentId);
        bool UpdateStudent(StudentEditDTO studentEditDTO);
    }
}
