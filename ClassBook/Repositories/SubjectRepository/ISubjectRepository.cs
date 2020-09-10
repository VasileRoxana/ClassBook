using ClassBook.Models;
using ClassBook.Repositories.GenericRepository;
using System;
using System.Linq;

namespace ClassBook.Repositories.SubjectRepository
{
    public interface ISubjectRepository : IGenericRepository<Subject>
    {
        IQueryable<Subject> GetAllSubjects();
        Subject GetSubjectById(Guid subjectId);
    }
}
