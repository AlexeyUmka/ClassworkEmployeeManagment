using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassworkEmployeeManagment.Infrastructure.Data;
using ClassworkEmployeeManagment.Infrastructure.Data.Contexts;
using ClassworkEmployeeManagment.Domain.Core.Basic_Models;
using ClassworkEmployeeManagment.UI.Models;
using ClassworkEmployeeManagment.UI.Models.Pagination;

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
                return View();
            }
            else return View();
        }
        public ActionResult Programmers(int page = 1)
        {
            List<ProgrammerForView> programmers = new List<ProgrammerForView>();
            foreach (var p in unitOfWork.Programmers.GetElementsOfRepository())
                programmers.Add(new ProgrammerForView(p));
            int pageSize = 5; // количество объектов на страницу
            IEnumerable<ProgrammerForView> programmersperpages = programmers.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = programmers.Count };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Programmers = programmersperpages};
            return View(ivm);
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