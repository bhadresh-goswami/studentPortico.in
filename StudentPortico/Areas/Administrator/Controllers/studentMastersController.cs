using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentPortico.Areas.Administrator.Models;

namespace StudentPortico.Areas.Administrator.Controllers
{
    public class studentMastersController : Controller
    {
        private dbStudentEntities db = new dbStudentEntities();

        // GET: Administrator/studentMasters
        public ActionResult Index()
        {
            return View(db.studentMasters.ToList());
        }

        // GET: Administrator/studentMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentMaster studentMaster = db.studentMasters.Find(id);
            if (studentMaster == null)
            {
                return HttpNotFound();
            }
            return View(studentMaster);
        }

        // GET: Administrator/studentMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/studentMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sid,sname,fname,lname,emailid,password,gender,image,college,country,state,city")] studentMaster studentMaster)
        {
            if (ModelState.IsValid)
            {
                db.studentMasters.Add(studentMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentMaster);
        }

        // GET: Administrator/studentMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentMaster studentMaster = db.studentMasters.Find(id);
            if (studentMaster == null)
            {
                return HttpNotFound();
            }
            return View(studentMaster);
        }

        // POST: Administrator/studentMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sid,sname,fname,lname,emailid,password,gender,image,college,country,state,city")] studentMaster studentMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentMaster);
        }

        // GET: Administrator/studentMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentMaster studentMaster = db.studentMasters.Find(id);
            if (studentMaster == null)
            {
                return HttpNotFound();
            }
            return View(studentMaster);
        }

        // POST: Administrator/studentMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            studentMaster studentMaster = db.studentMasters.Find(id);
            db.studentMasters.Remove(studentMaster);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
