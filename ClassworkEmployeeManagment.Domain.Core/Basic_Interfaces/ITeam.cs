using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassworkEmployeeManagment.Domain.Core.Basic_Interfaces
{
    public interface ITeam<TPersons, TTeamType> where TPersons:class where TTeamType:class
    {
        int TeamID { get; set; }
        ICollection<TPersons> Members { get; set; }
        IProject<TPersons,TTeamType> Project { get; set; }
    }
}
