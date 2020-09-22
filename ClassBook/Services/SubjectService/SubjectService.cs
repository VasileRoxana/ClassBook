using AutoMapper;
using ClassBook.DTOs.SubjectDTOs;
using ClassBook.Models;
using ClassBook.Repositories.SubjectGradesRepository;
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
        private readonly ISubjectGradesRepository _subjectGradeRepository;
        private readonly IMapper _mapper;
        public SubjectService(ISubjectRepository subjectRepository,
                              ISubjectGradesRepository subjectGradeRepository,
                              IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _subjectGradeRepository = subjectGradeRepository;
            _mapper = mapper;
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

            var subjectGrades = _subjectGradeRepository.GetSubjectGradesBySubjectId(subjectId);

            foreach(SubjectGrade subjectGrade in subjectGrades)
            {
                _subjectGradeRepository.Delete(subjectGrade);
            }

            status = _subjectGradeRepository.Save();

            if (!status)
            {
                throw new NullReferenceException();
            }
        }

        public SubjectGetByIdDTO GetSubjectById(Guid subjectId)
        {
            if (subjectId == null)
            {
                throw new NullReferenceException();
            }

            var subject = _subjectRepository.GetSubjectById(subjectId);

            if (subject == null)
            {
                throw new NullReferenceException();
            }

            var subjectGetByIdDTO = _mapper.Map<SubjectGetByIdDTO>(subject);

            return subjectGetByIdDTO;
        }
    }
}
