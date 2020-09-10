using ClassBook.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Models
{
    public class Student : BaseEntity
    {
        [Required] 
        public string Name { get; set; }

        [Column(TypeName = "date")]
        [Required] public DateTime DateOfBirth { get; set; }
        public ICollection<SubjectGrade> Grades { get; set; }
    }
}
