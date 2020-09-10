using ClassBook.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Models
{
    public class Grade : BaseEntity
    {
        [Required] public float Value { get; set; }
        [Required] public DateTime DateGiven { get; set; }
    }
}
