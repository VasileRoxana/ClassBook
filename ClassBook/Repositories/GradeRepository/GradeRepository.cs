using ClassBook.Models;
using ClassBook.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ClassBook.Repositories.GradeRepository
{
    public class GradeRepository : GenericRepository<Grade>, IGradeRepository
    {
        public GradeRepository(ClassBookDbContext dbContext) : base(dbContext)
        {

        }
        public Grade GetGrade(Guid gradeId)
        {
            return _table.AsNoTracking()
                .FirstOrDefault(x => x.Id == gradeId);
        }

        public IQueryable<Grade> GetGrades()
        {
            return _table.AsNoTracking();
        }
    }
}
