using ClassBook.DTOs.SubjectDTOs;
using ClassBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Services.SubjectService
{
    public interface ISubjectService
    {
        void Delete(Guid subjectId);
        SubjectGetByIdDTO GetSubjectById(Guid subjectId);
    }
}
