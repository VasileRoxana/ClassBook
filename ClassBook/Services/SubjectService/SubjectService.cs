using ClassBook.Models;
using ClassBook.Repositories.SubjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Services.SubjectService
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public void Delete(Guid subjectId)
        {
            Subject subject = _subjectRepository.GetSubjectById(subjectId);

            if (subject == null)
            {
                throw new NullReferenceException();
            }

            _subjectRepository.Delete(subject);
            var status = _subjectRepository.Save();

            if(!status)
            {
                throw new NullReferenceException();
            }
        }
    }
}
