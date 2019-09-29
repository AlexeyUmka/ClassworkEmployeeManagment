using ClassworkEmployeeManagment.Domain.Core.Basic_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassworkEmployeeManagment.Domain.Core.Basic_Models
{
    public class ProgrammersTeam : ITeam<Programmer, ProgrammersTeam>
    {
        [Key]
        public int TeamID { get; set; }
        [Required(ErrorMessage ="Please enter the members of team")]
        public ICollection<Programmer> Members { get; set; }
        [Required(ErrorMessage ="Please enter the Project for team")]
        public IProject<Programmer, ProgrammersTeam> Project { get; set; }
    }
}
