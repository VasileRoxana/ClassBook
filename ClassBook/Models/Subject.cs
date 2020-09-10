using ClassBook.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Models
{
    public class Subject : BaseEntity
    {
        [Required] public string Name { get; set; }
        [Required] public string Teacher { get; set; }
        public ICollection<SubjectGrade> Grades { get; set; }
    }
}
