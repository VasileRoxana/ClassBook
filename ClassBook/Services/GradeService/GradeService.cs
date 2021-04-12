using AutoMapper;
using ClassBook.DTOs.GradeDTOs;
using ClassBook.Models;
using ClassBook.Repositories.AccountRepository;
using ClassBook.Repositories.GradeRepository;
using ClassBook.Repositories.SubjectGradesRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using System.Web.Http.Results;

namespace ClassBook.Services.GradeService
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly ISubjectGradesRepository _subjectGradeRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        public GradeService(IGradeRepository gradeRepository,
                            ISubjectGradesRepository subjectGradeRepository,
                            IAccountRepository accountRepository,
                            IMapper mapper,
                            IHttpContextAccessor httpContextAccessor,
                            UserManager<AppUser> userManager)
        {
            _gradeRepository = gradeRepository;
            _subjectGradeRepository = subjectGradeRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public Grade GetGradeById(Guid gradeId)
        {
            var grade = _gradeRepository.GetGrade(gradeId);

            if(grade == null)
            {
                throw new NullReferenceException();
            }

            return grade;
        }

        public List<GradeBySubjectIdDTO> GetGradesBySubjectId(Guid subjectId)
        {
            if(subjectId == null)
            {
                throw new NullReferenceException();
            }

            var subjectGrades = _subjectGradeRepository.GetSubjectGradesBySubjectId(subjectId);

            if (subjectGrades == null)
            {
                throw new NullReferenceException();
            }

            var grades = subjectGrades.Select(x => x.Grade).ToList();
            

            if (grades == null)
            {
                return null; //a student may have no grades yet and thats ok
            }
            else
            {
                var gradesDTO = new List<GradeBySubjectIdDTO>();

                foreach (Grade grade in grades)
                {
                    gradesDTO.Add(_mapper.Map<GradeBySubjectIdDTO>(grade));
                }

                return gradesDTO;
            }         
        }

        //public IEnumerable<IGrouping<string, SubjectGrade>> GetGradesGroupedBySubjectId(Guid userId)
        public dynamic GetGradesGroupedBySubjectId(Guid userId)
        {
            if (userId == null)
            {
                throw new NullReferenceException();
            }

            var studentId = _accountRepository.GetStudentId(userId);

            var subjectGradesGrouped = _subjectGradeRepository.GetSubjectGradesByStudentId(studentId)
                .Select(x => x.Id)
                    .ToList();
                    //.GroupBy(x => x.Subject.Name);

            return subjectGradesGrouped;
        }

        public void UpdateGrade(Guid gradeId, IDictionary<string, string> properties)
        {

            if (properties == null)
            {
                throw new NullReferenceException("Input is null");
            }

            var grade = _gradeRepository.GetGrade(gradeId); 

            if (grade == null)
            {
                throw new NullReferenceException("Grade is null");
            }

            foreach (var property in properties)
            {
                var dbProperty = grade.GetType().GetProperty(property.Key);

                if (dbProperty != null)
                {
                    if (property.Key == "Value")
                    {
                        float newValue;

                        if (float.TryParse(property.Value, out newValue))
                        {
                            if(newValue < 1 || newValue >10)
                            {
                                throw new NullReferenceException("Invalid float value for Grade Value");                                
                            }

                            dbProperty.SetValue(grade, newValue, null);
                        }
                        else
                        {
                            throw new NullReferenceException("Invalid float value for Grade Value");
                        }
                    }
                    else if(property.Key == "DateGiven")
                    {
                        DateTime newDate;

                        if(DateTime.TryParse(property.Value, out newDate))
                        {
                            dbProperty.SetValue(grade, newDate, null);
                        }
                        else
                        {
                            throw new NullReferenceException("Invalid dateTime value for Grade DateGiven");
                        }
                    }
                }
                else
                {
                    throw new NullReferenceException("Could not update these properties");
                }
            }

            _gradeRepository.Update(grade);
            _gradeRepository.Save();
        }
    }
}
