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
    public class GoalsController : Controller
    {
        private GradAppEntities db = new GradAppEntities();

        // GET: Goals
        public ActionResult Index()
        {
            var goals = db.Goals.Include(g => g.Rotation);
            return View(goals.ToList());
        }

        // GET: Goals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goal goal = db.Goals.Find(id);
            if (goal == null)
            {
                return HttpNotFound();
            }
            return View(goal);
        }

        // GET: Goals/Create
        public ActionResult Create()
        {
            ViewBag.RotationID = new SelectList(db.Rotations, "RotationID", "RotationID");
            return View();
        }

        // POST: Goals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GoalID,GoalName,RotationID,GoalComment,GoalFeedback")] Goal goal)
        {
            if (ModelState.IsValid)
            {
                db.Goals.Add(goal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RotationID = new SelectList(db.Rotations, "RotationID", "RotationID", goal.RotationID);
            return View(goal);
        }

        // GET: Goals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goal goal = db.Goals.Find(id);
            if (goal == null)
            {
                return HttpNotFound();
            }
            ViewBag.RotationID = new SelectList(db.Rotations, "RotationID", "RotationID", goal.RotationID);
            return View(goal);
        }

        // POST: Goals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GoalID,GoalName,RotationID,GoalComment,GoalFeedback")] Goal goal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RotationID = new SelectList(db.Rotations, "RotationID", "RotationID", goal.RotationID);
            return View(goal);
        }

        // GET: Goals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goal goal = db.Goals.Find(id);
            if (goal == null)
            {
                return HttpNotFound();
            }
            return View(goal);
        }

        // POST: Goals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Goal goal = db.Goals.Find(id);
            db.Goals.Remove(goal);
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

        public ActionResult Graduate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goal goal = db.Goals.Where(r => r.GoalID == id).First();
            if (goal == null)
            {
                return HttpNotFound();
            }
            return View(goal);
        }

        public ActionResult Manager(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goal goal = db.Goals.Where(r => r.GoalID == id).First();
            if (goal == null)
            {
                return HttpNotFound();
            }
            return View(goal);
        }
    }
}
