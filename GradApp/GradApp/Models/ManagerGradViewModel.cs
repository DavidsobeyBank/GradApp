using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradApp.Models
{
    public class ManagerGradViewModel
    {
        public Rotation Rotation { get; set; }
        public Project Project { get; set; }
        public ManagerGradViewModel(Rotation rotation, Project project)
        { 
            Rotation = rotation;
            Project = project;
        }
    }
}