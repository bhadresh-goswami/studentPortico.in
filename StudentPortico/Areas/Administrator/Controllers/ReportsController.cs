using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using StudentPortico.Areas.Administrator.Models;

namespace StudentPortico.Areas.Administrator.Controllers
{
    public class ReportsController : Controller
    {
        dbStudentEntities db = new dbStudentEntities();
        // GET: Administrator/Reports
        public ActionResult Exams()
        {
            return View(db.exammasters.ToList());
        }
        public ActionResult Assignment()
        {
            return View(db.assignmentMasters.ToList());
        }
        public ActionResult Student()
        {
            return View(db.studentMasters.ToList());
        }
        public ActionResult Faculty()
        {
            return View(db.facultymasters.ToList());
        }
        public ActionResult Feedback()
        {
            return View(db.feedbackmasters.ToList());
        }
    }
}