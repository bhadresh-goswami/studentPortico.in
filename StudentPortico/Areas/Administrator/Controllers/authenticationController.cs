using StudentPortico.Areas.Administrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentPortico.Areas.Administrator.Controllers
{
    public class authenticationController : Controller
    {
        private dbStudentEntities db = new dbStudentEntities();
        // GET: Administrator/authentication
        public ActionResult login()
        {


            return View();
        }
        [HttpPost]
        public ActionResult login(adminMaster adminMaster)
        {
            try
            {

                adminMaster data = db.adminMasters.SingleOrDefault(a => a.emailid == adminMaster.emailid && a.password == adminMaster.password);
                if (data != null)
                {
                    TempData["Message"] = "Welcome admin!";
                    Session["adminDetails"] = data.name;
                    return RedirectToAction("index", "adminHome");
                }
                TempData["Error"] = "Wrong Login Details!";

            }
            catch (Exception ex)
            {

                TempData["Error"] = ex.Message;
            }
            return View();
        }

    }
}