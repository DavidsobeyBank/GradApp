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
    public class ProjectWishListsController : Controller
    {
        private GradAppEntities db = new GradAppEntities();

        // GET: ProjectWishLists
        public ActionResult Index()
        {
            var projectWishLists = db.ProjectWishLists.Include(p => p.Graduate).Include(p => p.Project);
            return View(projectWishLists.ToList());
        }

        // GET: ProjectWishLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectWishList projectWishList = db.ProjectWishLists.Find(id);
            if (projectWishList == null)
            {
                return HttpNotFound();
            }
            return View(projectWishList);
        }

        // GET: ProjectWishLists/Create
        public ActionResult Create()
        {
            ViewBag.GraduateID = new SelectList(db.Graduates, "GraduateID", "Name");
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            return View();
        }

        // POST: ProjectWishLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WishListID,ProjectID,GraduateID,Moivation")] ProjectWishList projectWishList)
        {
            if (ModelState.IsValid)
            {
                db.ProjectWishLists.Add(projectWishList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GraduateID = new SelectList(db.Graduates, "GraduateID", "Name", projectWishList.GraduateID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectWishList.ProjectID);
            return View(projectWishList);
        }

        // GET: ProjectWishLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectWishList projectWishList = db.ProjectWishLists.Find(id);
            if (projectWishList == null)
            {
                return HttpNotFound();
            }
            ViewBag.GraduateID = new SelectList(db.Graduates, "GraduateID", "Name", projectWishList.GraduateID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectWishList.ProjectID);
            return View(projectWishList);
        }

        // POST: ProjectWishLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WishListID,ProjectID,GraduateID,Moivation")] ProjectWishList projectWishList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectWishList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GraduateID = new SelectList(db.Graduates, "GraduateID", "Name", projectWishList.GraduateID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectWishList.ProjectID);
            return View(projectWishList);
        }

        // GET: ProjectWishLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectWishList projectWishList = db.ProjectWishLists.Find(id);
            if (projectWishList == null)
            {
                return HttpNotFound();
            }
            return View(projectWishList);
        }

        // POST: ProjectWishLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectWishList projectWishList = db.ProjectWishLists.Find(id);
            db.ProjectWishLists.Remove(projectWishList);
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

        // GET: ProjectWishLists/Create
        public ActionResult GraduateCreate(int? projectID)
        {
            int graduateID = db.Graduates.Where(g => g.Email == User.Identity.Name).First().GraduateID;
            ViewBag.GraduateID = new SelectList(db.Graduates.Where(g => g.GraduateID == graduateID), "GraduateID", "Name");
            ViewBag.ProjectID = new SelectList(db.Projects.Where(p => p.ProjectID == projectID), "ProjectID", "ProjectName");
            return View();
        }

        // POST: ProjectWishLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GraduateCreate([Bind(Include = "WishListID,ProjectID,GraduateID,Moivation")] ProjectWishList projectWishList)
        {
            if (ModelState.IsValid)
            {
                db.ProjectWishLists.Add(projectWishList);
                db.SaveChanges();
                return RedirectToAction("Graduate", "Rotations");
            }

            ViewBag.GraduateID = new SelectList(db.Graduates, "GraduateID", "Name", projectWishList.GraduateID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", projectWishList.ProjectID);
            return View(projectWishList);
        }
    }
}
