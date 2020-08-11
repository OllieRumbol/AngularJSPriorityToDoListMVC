using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriorityToDoListMVC.Constants
{
    public class FileConstants
    {
        public static readonly string filePath = System.Web.Hosting.HostingEnvironment.MapPath("/CSV/Tasks.csv");

        public static readonly string HighPriorityFilePath = System.Web.Hosting.HostingEnvironment.MapPath("/CSV/HighPriorityTasks.csv");

        public static readonly string MediumPriorityFilePath = System.Web.Hosting.HostingEnvironment.MapPath("/CSV/MediumPriorityTasks.csv");

        public static readonly string LowPriorityFilePath = System.Web.Hosting.HostingEnvironment.MapPath("/CSV/LowPriorityTasks.csv");

        public static readonly string CompletedFilePath = System.Web.Hosting.HostingEnvironment.MapPath("/CSV/CompletedTasks.csv");
    }
}