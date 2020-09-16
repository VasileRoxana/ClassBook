using ClassBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.DTOs.StudentDTOs
{
    public class StudentHomeDTO
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<SubjectGrade> Grades { get; set; }
    }
}
