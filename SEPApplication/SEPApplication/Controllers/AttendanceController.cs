using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SEPApplication.Models;

namespace SEPApplication.Controllers
{
    public class AttendanceController : Controller
    {
        private sepoopcsEntities db = new sepoopcsEntities();

        // GET: /Attendance/
        public ActionResult Index()
        {
            var attendances = db.Attendances.Include(a => a.Member).Include(a => a.Session);
            return View(attendances.ToList());
        }

        // GET: /Attendance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // GET: /Attendance/Create
        public ActionResult Create()
        {
            ViewBag.Member_id = new SelectList(db.Members, "id", "Code");
            ViewBag.Session_id = new SelectList(db.Sessions, "id", "Info");
            return View();
        }

        // POST: /Attendance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,Session_id,Member_id")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Attendances.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Member_id = new SelectList(db.Members, "id", "Code", attendance.Member_id);
            ViewBag.Session_id = new SelectList(db.Sessions, "id", "Info", attendance.Session_id);
            return View(attendance);
        }

        // GET: /Attendance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.Member_id = new SelectList(db.Members, "id", "Code", attendance.Member_id);
            ViewBag.Session_id = new SelectList(db.Sessions, "id", "Info", attendance.Session_id);
            return View(attendance);
        }

        // POST: /Attendance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Session_id,Member_id")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Member_id = new SelectList(db.Members, "id", "Code", attendance.Member_id);
            ViewBag.Session_id = new SelectList(db.Sessions, "id", "Info", attendance.Session_id);
            return View(attendance);
        }

        // GET: /Attendance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: /Attendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendance attendance = db.Attendances.Find(id);
            db.Attendances.Remove(attendance);
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
