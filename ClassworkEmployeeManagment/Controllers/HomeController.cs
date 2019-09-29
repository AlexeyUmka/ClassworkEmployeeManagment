using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassworkEmployeeManagment.Infrastructure.Data;
using ClassworkEmployeeManagment.Infrastructure.Data.Contexts;
using ClassworkEmployeeManagment.Domain.Core.Basic_Models;

namespace ClassworkEmployeeManagment.UI.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork;
        public HomeController()
        {
            unitOfWork = new UnitOfWork();
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ProjectForProgrammers project)
        {
            if (project.StartTime < DateTime.Now)
                ModelState.AddModelError("StartTime", "Start time must be more than now time");
            if (project.FinishTime <= project.StartTime)
                ModelState.AddModelError("FinishTime", "Finish time must be more than StartTime");
            if (ModelState.IsValid)
            {
                ProjectTeamBuilder projectTeamBuilder = new ProjectTeamBuilder(unitOfWork, project);
                if (projectTeamBuilder.FormTeamForProject(3, 3))
                {
                    project.Team = projectTeamBuilder.ProgrammersTeam;
                    unitOfWork.Save();
                    return View("About", unitOfWork.ProgrammersTeams.GetElementsOfRepository());
                }
                else
                {
                    ModelState.AddModelError("StartTime", "Can't create a team");
                    return View();
                }
            }
            else return View();
        }
        public ActionResult About()
        {
            return View(unitOfWork.ProgrammersTeams.GetElementsOfRepository());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}