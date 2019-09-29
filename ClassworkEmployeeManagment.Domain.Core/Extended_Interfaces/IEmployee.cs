using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ClassworkEmployeeManagment.Domain.Core.Basic_Interfaces;

namespace ClassworkEmployeeManagment.Domain.Core.Extended_Interfaces
{
    /// <summary>
    /// The enumerable about type of Employees of the company
    /// </summary>
    public enum Appointment
    {
        [Display(Name ="Programmer")]
        Programmer,
        [Display(Name = "Project Manager")]
        ProjectManager,
        [Display(Name = "Designer")]
        Designer
    }
    public interface IEmployee : IPerson
    {   
        [Required(ErrorMessage ="Please enter the birht day")]
        [DataType(DataType.Date)]
        DateTime BirthDay { get; set; }
        [Required(ErrorMessage = "Please enter the salary of Employee")]
        [DataType(DataType.Currency)]
        [Range(1, uint.MaxValue, ErrorMessage = "The salary must be in range(from 1 to 4 294 967 295)")]
        uint SalaryPerMonth { get; set; }
        [Required]
        Appointment Appointment { get;}
    }
}
