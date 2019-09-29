using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassworkEmployeeManagment.Domain.Interfaces.Basic_Interfaces;
using ClassworkEmployeeManagment.Domain.Core.Basic_Models;
using ClassworkEmployeeManagment.Infrastructure.Data.Contexts;
using ClassworkEmployeeManagment.Infrastructure.Data.Repositories;

namespace ClassworkEmployeeManagment.Infrastructure.Data
{
    public class ProjectTeamBuilder
    {
        private UnitOfWork UnitOfWork { get; set; }
        public ProgrammersTeam ProgrammersTeam { get; set; }
        private ProjectForProgrammers ProjectForProgrammers { get; set; }
        public ProjectTeamBuilder(UnitOfWork unitOfWork, ProjectForProgrammers projectForProgrammers)
        {
            UnitOfWork = unitOfWork;
            ProjectForProgrammers = projectForProgrammers;
        }
        public bool FormTeamForProject(int programmersPerLevel, int maxProjectsForOneProgrammer)
        {
            ProgrammersTeam = new ProgrammersTeam();
            if (IsEnoughFreeProgrammers(maxProjectsForOneProgrammer, programmersPerLevel))
            {
                ProgrammersTeam.Project = ProjectForProgrammers;
                int needFreeProgrammers = ProjectForProgrammers.DifficultyLevel * programmersPerLevel;
                int programmersAdded = 0;
                ProgrammersTeam.Members = new List<Programmer>();
                foreach (Programmer programmer in UnitOfWork.Programmers.GetElementsOfRepository())
                {
                    //Если не занят, добавляем в комманду
                    if (!IsBusyAtTargetTime(programmer))
                    {
                        ProgrammersTeam.Members.Add(programmer);
                        programmersAdded++;
                    }
                    //Набралось достаточное кол-во, выходим
                    if (programmersAdded == needFreeProgrammers)
                        break;
                }
                UnitOfWork.ProgrammersTeams.Create(ProgrammersTeam);
                UnitOfWork.Save();
                return true;
            }
            else
                return false;
        }
        //Функция для проверки достаточного кол-ва программистов
        private bool IsEnoughFreeProgrammers(int maxProjectsForOneProgrammer = 3, int programmersPerLevel = 3)
        {
            int needFreeProgrammers = ProjectForProgrammers.DifficultyLevel * programmersPerLevel;
            int freeProgrammersAmount = 0;
            foreach(Programmer programmer in UnitOfWork.Programmers.GetElementsOfRepository())
            {
                //Если не занят, значит свободен
                if (!IsBusyAtTargetTime(programmer))
                    freeProgrammersAmount++;
                if (freeProgrammersAmount == needFreeProgrammers)
                    break;
            }
            if (freeProgrammersAmount == needFreeProgrammers)
                return true;
            else
                return false;
        }
        private bool IsBusyAtTargetTime(Programmer programmer,int maxProjectsForOneProgrammer = 3)
        {
            if (programmer.Projects != null)
            {
                //Кол-во проектов у данного программиста в нужных временных рамках
                int projectsOfTargetProgrammerAtTargetTime = 1;
                foreach (ProjectForProgrammers project in programmer.Projects)
                {
                    //Конец целевого проекта должен быть меньше чем начало существующего
                    //или
                    //Начало целевого проекта должно быть больше чем конец существующего
                    if ((ProjectForProgrammers.FinishTime < project.StartTime) || (ProjectForProgrammers.StartTime > project.FinishTime))
                        projectsOfTargetProgrammerAtTargetTime++;
                }
                if (projectsOfTargetProgrammerAtTargetTime <= maxProjectsForOneProgrammer)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
    }
}
