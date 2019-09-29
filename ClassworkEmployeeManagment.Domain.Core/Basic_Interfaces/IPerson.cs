using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassworkEmployeeManagment.Domain.Core.Basic_Interfaces
{
    public interface IPerson
    {
        [Key]
        int PersonID { get; set; }
        [Required(ErrorMessage = "Enter your name please")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The name's length must be in range(from 2 to 50 chars)")]
        string Name { get; set; }
        [Required(ErrorMessage = "Enter your surname please")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The surname's length must be in range(from 2 to 50 chars)")]
        string SurName { get; set; }
        [Required(ErrorMessage = "Enter your patronymic please")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The patronymic's length must be in range(from 2 to 50 chars)")]
        string Patronymic { get; set; }
    }
}
