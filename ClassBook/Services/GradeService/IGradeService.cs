using ClassBook.DTOs.GradeDTOs;
using ClassBook.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Services.GradeService
{
    public interface IGradeService
    {
        void UpdateGrade(Guid gradeId, IDictionary<string, string> properties);
        List<GradeBySubjectIdDTO> GetGradesBySubjectId(Guid subjectId);
        //IEnumerable<IGrouping<string, SubjectGrade>> GetGradesGroupedBySubjectId(Guid userId);
        dynamic GetGradesGroupedBySubjectId(Guid userId);
        Grade GetGradeById(Guid gradeId);
    }
}
