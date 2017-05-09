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
    public class GraduatesController : Controller
    {
        private GradAppEntities db = new GradAppEntities();

        // GET: Graduates
        public ActionResult Index()
        {
            return View(db.Graduates.ToList());
        }

        // GET: Graduates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate graduate = db.Graduates.Find(id);
            if (graduate == null)
            {
                return HttpNotFound();
            }
            return View(graduate);
        }

        // GET: Graduates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Graduates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GraduateID,Name,Surname,Email,PreferredRole,Degree,GraduateYear")] Graduate graduate)
        {
            if (ModelState.IsValid)
            {
                db.Graduates.Add(graduate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(graduate);
        }

        // GET: Graduates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate graduate = db.Graduates.Find(id);
            if (graduate == null)
            {
                return HttpNotFound();
            }
            return View(graduate);
        }

        // POST: Graduates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GraduateID,Name,Surname,Email,PreferredRole,Degree,GraduateYear")] Graduate graduate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(graduate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(graduate);
        }

        // GET: Graduates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Graduate graduate = db.Graduates.Find(id);
            if (graduate == null)
            {
                return HttpNotFound();
            }
            return View(graduate);
        }

        // POST: Graduates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Graduate graduate = db.Graduates.Find(id);
            db.Graduates.Remove(graduate);
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
