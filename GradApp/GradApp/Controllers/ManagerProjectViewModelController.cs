using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GradApp.Models;
using GradApp.ViewModels;

namespace GradApp.Controllers
{
    public class ManagerProjectViewModelController : Controller
    {
        private GradAppEntities db = new GradAppEntities();
        private List<ManagerProjectViewModel> ManagerProjectViewModelList = new List<ManagerProjectViewModel>();

        // GET: ManagerProjectViewModel
        public ActionResult Manager()
        {
            var managerID = db.Managers.Where(g => g.Email == /*User.Identity.Name*/"Nicole.Borges@standardbank.co.za").Select(r => r.ManagerID).Single();

            var customList = db.Rotations.Join(db.Managers, rotation => rotation.Project.ManagerID, manager => manager.ManagerID, (rotation, manager) => new { Rotation = rotation, Manager = manager }).Where( w => w.Manager.ManagerID == managerID);

            foreach (var item in customList)
            {
                ManagerProjectViewModel mpVM = new ManagerProjectViewModel();

                if (ManagerProjectViewModelList.Count() > 0)
                {
                    var index = ManagerProjectViewModelList.FindIndex(s => s.project.ProjectID == item.Rotation.ProjectID) ;
                    if (index > 0)
                    {
                        ManagerProjectViewModelList[index].graduates.Add(item.Rotation.Graduate);
                    }
                }
                else
                {
                    mpVM.project = item.Rotation.Project;
                    mpVM.graduates = new List<Graduate>();
                    mpVM.graduates.Add(item.Rotation.Graduate);
                    ManagerProjectViewModelList.Add(mpVM);
                }
            }            

            return View("~/Views/Home/Manager.cshtml",ManagerProjectViewModelList);
        }
    }
}