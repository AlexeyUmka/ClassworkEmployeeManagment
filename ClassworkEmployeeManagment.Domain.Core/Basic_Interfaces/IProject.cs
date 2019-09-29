using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassworkEmployeeManagment.Domain.Core.Basic_Interfaces
{
    public interface IProject<TPersons, TTeamType> where TPersons : class where TTeamType : class
    {
        int ProjectID { get; set; }
        string ProjectName { get; set; }
        ITeam<TPersons, TTeamType> Team { get; set; }
        int DifficultyLevel { get; set; }
        DateTime StartTime { get; set; }
        DateTime FinishTime { get; set; }
    }
}
