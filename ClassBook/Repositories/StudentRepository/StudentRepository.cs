using ClassBook.Models;
using ClassBook.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ClassBook.Repositories.StudentRepository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly ClassBookDbContext _context;
        public StudentRepository(ClassBookDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public Student GetStudent(Guid studentId)
        {
            return _table.AsNoTracking()
                .Include(d => d.Grades)
                .FirstOrDefault(x => x.Id == studentId);
        }

        public IQueryable<Student> GetStudents()
        {
            return _table.AsNoTracking();
        }

        public IQueryable<Student> GetStudentsByIds(List<Guid> studentsIds)
        {
            return _table.AsNoTracking()
                .Where(x => studentsIds.Contains(x.Id));
        }

        public Student Add(Student student)
        {
            student.Grades = new List<SubjectGrade>();
            _table.Add(student);
            _context.SaveChanges();

            return student;
        }

        public void UpdateStudent(Student student) => Update(student);
    }
}
