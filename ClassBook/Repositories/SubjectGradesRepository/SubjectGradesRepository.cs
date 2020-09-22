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
            var subjects = _table.AsNoTracking()
                .Where(x => x.StudentId == studentId)
                .Include(d => d.Subject)
                .Include(d => d.Grade);

            return subjects;
        }

        public IEnumerable<IGrouping<Guid, SubjectGrade>> GetSubjectGradesGroupedBySubjectId(Guid subjectId)
        {
            //group by subject id

            var subjectGrades = _table.AsNoTracking()
                .Where(x => x.SubjectId == subjectId)
                .Include(d => d.Grade)
                .Include(d => d.Subject)
                .ToList()
                .GroupBy(x => x.SubjectId);

            return subjectGrades;
        }

        public IQueryable<SubjectGrade> GetSubjectGradesBySubjectId(Guid subjectId)
        {
            //group by subject id

            var subjectGrades = _table.AsNoTracking()
                .Where(x => x.SubjectId == subjectId)
                .Include(d => d.Grade);

            return subjectGrades;
        }
    }
}
