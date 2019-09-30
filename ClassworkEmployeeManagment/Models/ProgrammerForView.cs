using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassworkEmployeeManagment.Domain.Core.Basic_Models;

namespace ClassworkEmployeeManagment.UI.Models
{
    public class ProgrammerForView
    {
        public ProgrammerForView(Programmer p)
        {
            Name = p.Name;
            SurName = p.SurName;
            Patronymic = p.Patronymic;
            BirthDay = p.BirthDay;
            SalaryPerMonth = p.SalaryPerMonth;
            LevelOfSkill = p.LevelOfSkill;
        }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDay { get; set; }
        public int SalaryPerMonth { get; set; }
        public int LevelOfSkill { get; set; }
    }
}