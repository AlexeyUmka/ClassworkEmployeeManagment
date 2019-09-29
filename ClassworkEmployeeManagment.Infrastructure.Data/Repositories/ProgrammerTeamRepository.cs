using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassworkEmployeeManagment.Domain.Interfaces.Basic_Interfaces;
using ClassworkEmployeeManagment.Domain.Core.Basic_Models;
using ClassworkEmployeeManagment.Infrastructure.Data.Contexts;
using System.Data.Entity;

namespace ClassworkEmployeeManagment.Infrastructure.Data.Repositories
{
    public class ProgrammerTeamRepository : IRepository<ProgrammersTeam>
    {
        private EmployeeManagmentContext db;

        public ProgrammerTeamRepository(EmployeeManagmentContext context)
        {
            this.db = context;
        }

        public IEnumerable<ProgrammersTeam> GetElementsOfRepository()
        {
            return db.ProgrammersTeams.ToList();
        }

        public ProgrammersTeam GetElement(int id)
        {
            return db.ProgrammersTeams.Find(id);
        }

        public void Create(ProgrammersTeam programmersTeam)
        {
            db.ProgrammersTeams.Add(programmersTeam);
        }

        public void Update(ProgrammersTeam programmersTeam)
        {
            db.Entry(programmersTeam).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ProgrammersTeam programmersTeam = db.ProgrammersTeams.Find(id);
            if (programmersTeam != null)
                db.ProgrammersTeams.Remove(programmersTeam);
        }
    }
}
