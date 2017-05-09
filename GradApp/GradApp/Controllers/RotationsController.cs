using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GradApp.Models;

namespace GradApp.Controllers
{
    public class RotationsController : Controller
    {
        private GradAppEntities db = new GradAppEntities();

        // GET: Rotations
        public ActionResult Index()
        {
            var rotations = db.Rotations.Include(r => r.Graduate).Include(r => r.Project);
            return View(rotations.ToList());
        }

        // GET: Rotations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rotation rotation = db.Rotations.Find(id);
            if (rotation == null)
            {
                return HttpNotFound();
            }
            return View(rotation);
        }

        // GET: Rotations/Create
        public ActionResult Create()
        {
            ViewBag.GraduateID = new SelectList(db.Graduates, "GraduateID", "Name");
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            return View();
        }

        // POST: Rotations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RotationID,GraduateID,ProjectID")] Rotation rotation)
        {
            if (ModelState.IsValid)
            {
                db.Rotations.Add(rotation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GraduateID = new SelectList(db.Graduates, "GraduateID", "Name", rotation.GraduateID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", rotation.ProjectID);
            return View(rotation);
        }

        // GET: Rotations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rotation rotation = db.Rotations.Find(id);
            if (rotation == null)
            {
                return HttpNotFound();
            }
            ViewBag.GraduateID = new SelectList(db.Graduates, "GraduateID", "Name", rotation.GraduateID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", rotation.ProjectID);
            return View(rotation);
        }

        // POST: Rotations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RotationID,GraduateID,ProjectID")] Rotation rotation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rotation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GraduateID = new SelectList(db.Graduates, "GraduateID", "Name", rotation.GraduateID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", rotation.ProjectID);
            return View(rotation);
        }

        // GET: Rotations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rotation rotation = db.Rotations.Find(id);
            if (rotation == null)
            {
                return HttpNotFound();
            }
            return View(rotation);
        }

        // POST: Rotations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rotation rotation = db.Rotations.Find(id);
            db.Rotations.Remove(rotation);
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
