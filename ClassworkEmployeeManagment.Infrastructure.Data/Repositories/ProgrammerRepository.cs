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
    public class ProgrammerRepository : IRepository<Programmer>
    {
        private EmployeeManagmentContext db;

        public ProgrammerRepository(EmployeeManagmentContext context)
        {
            this.db = context;
        }

        public IEnumerable<Programmer> GetElementsOfRepository()
        {
            return db.Programmers.ToList();
        }

        public Programmer GetElement(int id)
        {
            return db.Programmers.Find(id);
        }

        public void Create(Programmer programmer)
        {
            db.Programmers.Add(programmer);
        }

        public void Update(Programmer programmer)
        {
            db.Entry(programmer).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Programmer Programmer = db.Programmers.Find(id);
            if (Programmer != null)
                db.Programmers.Remove(Programmer);
        }
    }
}
