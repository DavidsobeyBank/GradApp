using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GradApp.Models;
using System.Web.Security;

namespace GradApp.Controllers
{
    public class ManagersController : Controller
    {
        private GradAppEntities db = new GradAppEntities();

        // GET: Managers
        public ActionResult Index()
        {
            LoadRole();
            if (User.IsInRole("Graduate"))
            {
                return RedirectToAction("Graduate", "Managers");
            }
            else if (User.IsInRole("Manager"))
            {
                return RedirectToAction("Manager", "Managers");
            }
            else if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Signup", "Home");
            }
        }

        // GET: Managers/Details/5
        //[Authorize(Roles = "AdminRole,AnotherRole")]
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager manager = db.Managers.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // GET: Managers/Create
        public ActionResult Create()
        {
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "AreaName");
            return View();
        }

        // POST: Managers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ManagerID,Name,Surname,Email,Location,AreaID")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                db.Managers.Add(manager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "AreaName", manager.AreaID);
            return View(manager);
        }

        // GET: Managers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager manager = db.Managers.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "AreaName", manager.AreaID);
            return View(manager);
        }

        // POST: Managers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ManagerID,Name,Surname,Email,Location,AreaID")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaID = new SelectList(db.Areas, "AreaID", "AreaName", manager.AreaID);
            return View(manager);
        }

        // GET: Managers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager manager = db.Managers.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // POST: Managers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manager manager = db.Managers.Find(id);
            db.Managers.Remove(manager);
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

        public ActionResult Signup()
        {
            ViewBag.Message = "SignUp";

            return View();
        }
        //[CustomAuthorize(Roles = "Graduate")]
        public ActionResult Graduate()
        {
            var managers = db.Managers.Include(m => m.Area);
            return View(managers.ToList());
        }
        //[CustomAuthorize(Roles = "Manager")]
        public ActionResult Manager()
        {
            var managers = db.Managers.Include(m => m.Area);
            return View(managers.ToList());
        }

        public ActionResult ProjectDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rotation Rotation1 = db.Rotations.Where(r => r.ProjectID == id).First();
            if (Rotation1 == null)
            {
                return HttpNotFound();
            }
            return View(Rotation1);
        }

        public void LoadRole()
        {
            if (!Roles.RoleExists("Admin"))
            {
                Roles.CreateRole("Admin");
            }
            if (!Roles.RoleExists("Manager"))
            {
                Roles.CreateRole("Manager");
            }
            if (!Roles.RoleExists("Graduate"))
            {
                Roles.CreateRole("Graduate");
            }
            if (!Roles.RoleExists("Unassigned"))
            {
                Roles.CreateRole("Unassigned");
            }

            List<Graduate> GraduateList = new List<Graduate>();
            List<Manager> ManagerList = new List<Manager>();

            GraduateList = db.Graduates.ToList();
            ManagerList = db.Managers.ToList();

            foreach (Graduate G in GraduateList)
            {

                if (User.Identity.Name.Equals(G.Email, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!Roles.IsUserInRole(User.Identity.Name, "Graduate"))
                    {
                        Roles.AddUserToRole(User.Identity.Name, "Graduate");
                        break;
                    }
                }
            }
            foreach (Manager M in ManagerList)
            {

                if (User.Identity.Name.Equals(M.Email))
                {
                    if (!Roles.IsUserInRole(User.Identity.Name, "Manager"))
                    {
                        Roles.AddUserToRole(User.Identity.Name, "Manager");
                        break;
                    }
                }
            }
            //foreach (Admin M in ManagerList)
            //{

            //    if (User.Identity.Name.Equals(M.Email))
            //    {
            //        if (!Roles.IsUserInRole(User.Identity.Name, "Manager"))
            //        {
            //            Roles.AddUserToRole(User.Identity.Name, "Manager");
            //            break;
            //        }
            //    }
            //}
            if (!User.IsInRole("Graduate") && !User.IsInRole("Manager") && !User.IsInRole("Admin"))
            {
                Roles.AddUserToRole(User.Identity.Name, "Unassigned");
            }
        }
    }
}
