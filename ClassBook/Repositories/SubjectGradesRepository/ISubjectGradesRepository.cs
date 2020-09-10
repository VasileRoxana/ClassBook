using ClassBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Repositories.SubjectGradesRepository
{
    public interface ISubjectGradesRepository
    {
        IQueryable<SubjectGrade> GetSubjectGradesByStudentId(Guid studentId);

    }
}
