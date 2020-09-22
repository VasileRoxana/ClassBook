using ClassBook.Models;
using ClassBook.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Repositories.SubjectGradesRepository
{
    public interface ISubjectGradesRepository : IGenericRepository<SubjectGrade>
    {
        IQueryable<SubjectGrade> GetSubjectGradesByStudentId(Guid studentId);
        IEnumerable<IGrouping<Guid, SubjectGrade>> GetSubjectGradesGroupedBySubjectId(Guid subjectId);
        IQueryable<SubjectGrade> GetSubjectGradesBySubjectId(Guid subjectId);
    }
}
