using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GradApp.Models;

namespace GradApp.ViewModels
{
    public class ManagerProjectViewModel
    {
        public Project project { get; set; }
        public List<Graduate> graduates { get; set; }
    }
}