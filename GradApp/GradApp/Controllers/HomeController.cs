using GradApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GradApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        GradAppEntities db = new GradAppEntities();

        public ActionResult Index()
        {
            LoadRole();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        protected void LoadRole()
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
                    }
                }
            }
            if (!Roles.IsUserInRole(User.Identity.Name, "Graduate") || !Roles.IsUserInRole(User.Identity.Name, "Manager") || !Roles.IsUserInRole(User.Identity.Name, "Admin"))
            {
                Roles.AddUserToRole(User.Identity.Name, "Unassigned");
            }
        }

    }
}