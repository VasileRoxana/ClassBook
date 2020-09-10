using ClassBook.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Models
{
    public class SubjectGrade : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid GradeId { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public Grade Grade { get; set; }
    }
}
