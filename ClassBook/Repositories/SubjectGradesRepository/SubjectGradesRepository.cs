using ClassBook.Models;
using ClassBook.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Repositories.SubjectGradesRepository
{
    public class SubjectGradesRepository : GenericRepository<SubjectGrade>, ISubjectGradesRepository
    {
        public SubjectGradesRepository(ClassBookDbContext dbContext) : base(dbContext)
        {

        }
        public IQueryable<SubjectGrade> GetSubjectGradesByStudentId(Guid studentId)
        {
            return _table.AsNoTracking()
                .Where(x => x.StudentId == studentId)
                .Include(d => d.Subject); 
        }
    }
}
