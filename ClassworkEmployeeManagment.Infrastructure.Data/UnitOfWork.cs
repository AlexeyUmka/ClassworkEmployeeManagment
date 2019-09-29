using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassworkEmployeeManagment.Domain.Interfaces.Basic_Interfaces;
using ClassworkEmployeeManagment.Domain.Core.Basic_Models;
using ClassworkEmployeeManagment.Infrastructure.Data.Contexts;
using System.Data.Entity;
using System.Threading.Tasks;
using ClassworkEmployeeManagment.Infrastructure.Data.Repositories;

namespace ClassworkEmployeeManagment.Infrastructure.Data
{
    public class UnitOfWork : IDisposable
    {
        private EmployeeManagmentContext db = new EmployeeManagmentContext();
        private ProgrammerRepository programmerRepository;
        private ProgrammerTeamRepository programmerTeamRepository;
        private ProjectForProgrammerRepository projectForProgrammerRepository;
        public ProgrammerRepository Programmers
        {
            get
            {
                if (programmerRepository == null)
                    programmerRepository = new ProgrammerRepository(db);
                return programmerRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public ProgrammerTeamRepository ProgrammersTeams
        {
            get
            {
                if (programmerTeamRepository == null)
                    programmerTeamRepository = new ProgrammerTeamRepository(db);
                return programmerTeamRepository;
            }
        }
        public ProjectForProgrammerRepository ProjcetsForProgrammers
        {
            get
            {
                if (projectForProgrammerRepository == null)
                    projectForProgrammerRepository = new ProjectForProgrammerRepository(db);
                return projectForProgrammerRepository;
            }
        }
        private bool disposed = false;
        /// <summary>
        /// Forced disposing
        /// </summary>
        /// <param name="disposing">Indicates if we want to dispose of a database</param>
        public virtual void Dispose(bool disposing)
        {
            // if an object is not disposed
            if (!this.disposed)
            {
                // if we want to dispose of a database
                if (disposing)
                {
                    // dispose of a databse
                    db.Dispose();
                }

                // we indicate that database shouldn't be disposed anymore
                this.disposed = true;
            }
        }

        /// <summary>
        /// Explicit dispose of a databse and object
        /// </summary>
        public void Dispose()
        {
            // first, dispose of a database
            Dispose(true);

            // garbage collector call for this object
            GC.SuppressFinalize(this);
        }
    }
}
