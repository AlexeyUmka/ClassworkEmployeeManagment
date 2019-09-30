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
            unitOfWork.ProgrammersTeams.Create(new ProgrammersTeam() { Programmers = unitOfWork.Programmers.GetElementsOfRepository().ToList() });
            unitOfWork.ProgrammersTeams.Create(new ProgrammersTeam() { Programmers = unitOfWork.Programmers.GetElementsOfRepository().ToList() });
            unitOfWork.Save();
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
                return View();
            }
            else return View();
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}