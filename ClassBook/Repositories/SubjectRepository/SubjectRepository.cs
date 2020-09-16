using ClassBook.Models;
using ClassBook.Repositories.GenericRepository;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ClassBook.Repositories.SubjectRepository
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(ClassBookDbContext dbContext) : base(dbContext)
        {

        }


        public IQueryable<Subject> GetAllSubjects()
        {
            return _table.AsNoTracking();
        }

        public Subject GetSubjectById(Guid subjectId)
        {

            return _table.AsNoTracking()
                .FirstOrDefault(x => x.Id == subjectId);
        }
    }
}
