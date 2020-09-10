using ClassBook.Models;
using ClassBook.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Repositories.StudentRepository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        IQueryable<Student> GetStudentsByIds(List<Guid> studentsIds);
        IQueryable<Student> GetStudents();
        Student GetStudent(Guid studentId);
        Student Add(Student student);
        void UpdateStudent(Student student);
    }
}
