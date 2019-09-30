using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ClassworkEmployeeManagment.Domain.Core.Extended_Interfaces;
using ClassworkEmployeeManagment.Domain.Core.Basic_Interfaces;

namespace ClassworkEmployeeManagment.Domain.Core.Basic_Models
{
    public class Programmer : IEmployee
    {
        //IEmployee part
        [Key]
        public int PersonID { get; set; }

        [Required(ErrorMessage = "Enter your name please")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The name's length must be in range(from 2 to 50 chars)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your surname please")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The surname's length must be in range(from 2 to 50 chars)")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Enter your patronymic please")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The patronymic's length must be in range(from 2 to 50 chars)")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Please enter the birht day")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "Please enter the salary of Employee")]
        public int SalaryPerMonth { get; set; }

        [Required]
        public Appointment Appointment { get; } = Appointment.Programmer;
        //Special proporties
        [Required]
        [Range(1, 3)]
        public int LevelOfSkill { get; set; }

        
        public List<ProgrammersTeam> ProgrammersTeam { get; set; }
    }
}
