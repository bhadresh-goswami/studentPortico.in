using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using StudentPortico.Areas.Administrator.Models;


namespace StudentPortico.Areas.Administrator.Controllers
{
    public class adminHomeController : Controller
    {
        dbStudentEntities db = new dbStudentEntities();
        // GET: Administrator/adminHome
        public ActionResult Index()
        {
            if (Session["adminDetails"] == null)
            {
                TempData["Error"] = "Please Login to Access Dashboard!";
                return RedirectToAction("login", "authentication");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("login","authentication");
        }


        public ActionResult editProfile()
        {
            if (Session["adminDetails"] == null)
            {
                TempData["Error"] = "Please Login to Access Dashboard!";
                return RedirectToAction("login", "authentication");
            }


            string sesname = Session["adminDetails"].ToString();
            var data = db.adminMasters.Single(a => a.name == sesname);
            return View(data);
        }
        [HttpPost]
        public ActionResult editProfile(string emailid, string name)
        {
            try
            {
                if (Session["adminDetails"] == null)
                {
                    TempData["Error"] = "Please Login to Access Dashboard!";
                    return RedirectToAction("login", "authentication");
                }

                string sesname = Session["adminDetails"].ToString();
                var data = db.adminMasters.Single(a => a.name == sesname);
                data.emailid = emailid;
                data.name = name;
                db.SaveChanges();
                Session["adminDetails"] = name;
                TempData["Message"] = "Details Edit!";
            }
            catch (Exception ex)
            {

                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("index");
        }


        public ActionResult changePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult changePassword(string oldpass, string newpass)
        {
            string sname = Session["adminDetails"].ToString();
            var data = db.adminMasters.SingleOrDefault(a => a.name == sname && a.password == oldpass);
            if(data!=null)
            {
                data.password = newpass;
                db.SaveChanges();
                TempData["Message"] = "Password changed!";
                return RedirectToAction("index");
            }
            TempData["Error"] = "Old Password not match!";
            return View();
        }
    }
}