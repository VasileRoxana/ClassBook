using ClassBook.DTOs.GradeDTOs;
using ClassBook.Models;
using ClassBook.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Repositories.GradeRepository
{
    public interface IGradeRepository : IGenericRepository<Grade>
    {
        Grade GetGrade(Guid gradeId);
        IQueryable<Grade> GetGrades();
        void UpdateGrade(Grade grade);       
    }
}
