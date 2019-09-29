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
    public class ProjectForProgrammerRepository : IRepository<ProjectForProgrammers>
    {
        private EmployeeManagmentContext db;

        public ProjectForProgrammerRepository(EmployeeManagmentContext context)
        {
            this.db = context;
        }

        public IEnumerable<ProjectForProgrammers> GetElementsOfRepository()
        {
            return db.ProjectsForProgrammers.ToList();
        }

        public ProjectForProgrammers GetElement(int id)
        {
            return db.ProjectsForProgrammers.Find(id);
        }

        public void Create(ProjectForProgrammers projectForProgrammers)
        {
            db.ProjectsForProgrammers.Add(projectForProgrammers);
        }

        public void Update(ProjectForProgrammers projectForProgrammers)
        {
            db.Entry(projectForProgrammers).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ProjectForProgrammers projectForProgrammers = db.ProjectsForProgrammers.Find(id);
            if (projectForProgrammers != null)
                db.ProjectsForProgrammers.Remove(projectForProgrammers);
        }
    }
}
