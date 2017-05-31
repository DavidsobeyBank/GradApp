using GradApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using System.Net;

namespace GradApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        GradAppEntities db = new GradAppEntities();

        public ActionResult Index()
        {
            
            if(User.IsInRole("Graduate"))
            {
                return RedirectToAction("Graduate", "Home");
            }
            else if (User.IsInRole("Manager"))
            {
                return RedirectToAction("Manager", "Home");
            }
            else if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Signup", "Home");
            }
        }

        public ActionResult About()
        {
            try
            {
                if (User.IsInRole("Graduate"))
                {
                    Roles.RemoveUserFromRole(User.Identity.Name, "Graduate");
                    if(!User.IsInRole("Manager"))
                    Roles.AddUserToRole(User.Identity.Name, "Manager");
                }
                else if (User.IsInRole("Manager"))
                {
                    Roles.RemoveUserFromRole(User.Identity.Name, "Manager");
                    if (!User.IsInRole("Graduate"))
                    Roles.AddUserToRole(User.Identity.Name, "Graduate");
                }
            }
            catch(Exception e)
            { }
            

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Signup()
        {
            ViewBag.Message = "SignUp";

            return View();
        }
        //[CustomAuthorize(Roles = "Graduate")]
        public ActionResult Graduate()
        {
            ViewBag.Message = "Graduate Landing Page.";

            var graduate = db.Graduates.Where(g => g.Email == User.Identity.Name).Select(r => r.GraduateID).Single();

            List<Project> RotationList = db.Rotations.Where(r => r.GraduateID == graduate).Select(p => p.Project).ToList();
            return View(RotationList);
            //return View();
            
        }
        //[CustomAuthorize(Roles = "Manager")]
        public ActionResult Manager()
        {
            ViewBag.Message = "Manager Landing Page.";

            return RedirectToAction("Manager", "ManagerProjectViewModel");

        }


        public ActionResult Login()
        {
            LoadRole();
            return RedirectToAction("Index", "Home");

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
                try
                {
                    Roles.AddUserToRole(User.Identity.Name, "Unassigned");

                }
                catch(Exception)
                {

                }
            }
        }

    }
}