using ClassworkEmployeeManagment.Domain.Core.Basic_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassworkEmployeeManagment.Domain.Core.Basic_Models
{
    public class ProgrammersTeam 
    {
        [Key]
        public int TeamID { get; set; }
        public List<Programmer> Programmers { get; set; }
    }
}
