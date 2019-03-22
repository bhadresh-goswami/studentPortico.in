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
    public class assignmentMastersController : Controller
    {
        private dbStudentEntities db = new dbStudentEntities();

        // GET: Administrator/assignmentMasters
        public ActionResult Index()
        {
            return View(db.assignmentMasters.ToList());
        }

        // GET: Administrator/assignmentMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assignmentMaster assignmentMaster = db.assignmentMasters.Find(id);
            if (assignmentMaster == null)
            {
                return HttpNotFound();
            }
            return View(assignmentMaster);
        }

        // GET: Administrator/assignmentMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/assignmentMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "aid,adate,aurl,subjectname,description")] assignmentMaster assignmentMaster)
        {
            if (ModelState.IsValid)
            {
                db.assignmentMasters.Add(assignmentMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assignmentMaster);
        }

        // GET: Administrator/assignmentMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assignmentMaster assignmentMaster = db.assignmentMasters.Find(id);
            if (assignmentMaster == null)
            {
                return HttpNotFound();
            }
            return View(assignmentMaster);
        }

        // POST: Administrator/assignmentMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "aid,adate,aurl,subjectname,description")] assignmentMaster assignmentMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignmentMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assignmentMaster);
        }

        // GET: Administrator/assignmentMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            assignmentMaster assignmentMaster = db.assignmentMasters.Find(id);
            if (assignmentMaster == null)
            {
                return HttpNotFound();
            }
            return View(assignmentMaster);
        }

        // POST: Administrator/assignmentMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            assignmentMaster assignmentMaster = db.assignmentMasters.Find(id);
            db.assignmentMasters.Remove(assignmentMaster);
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
