using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassworkEmployeeManagment.Domain.Core.Basic_Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ClassworkEmployeeManagment.Domain.Core.Basic_Models
{
    public class ProjectForProgrammers 
    {
        [Key]
        public int ProjectID { get; set; }
        [Required(ErrorMessage = "Please enter the Name of project")]
        [StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "Length must be more than 5 chars and less than 50")]
        public string ProjectName { get; set; }
        [Required]
        public ProgrammersTeam ProgrammersTeam { get; set; }  
        
        [Required(ErrorMessage = "Please enter the Diffiuculty level of project")]
        [Range(1, 5)]
        public int DifficultyLevel { get; set; }
        [Required(ErrorMessage = "Please enter the start time of project")]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "Please enter the finish time of project")]
        public DateTime FinishTime { get; set; }
    }
}
