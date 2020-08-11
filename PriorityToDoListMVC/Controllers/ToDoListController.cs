using PriorityToDoListMVC.Constants;
using PriorityToDoListMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PriorityToDoListMVC.Controllers
{
    public class ToDoListController : Controller
    {
        private EditCSVFile edit;

        public ToDoListController()
        {
            edit = new EditCSVFile();
        }

        // GET: ToDoList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PriorityToDoList()
        {
            return View();
        }

        private string ConvertLevelToPath(int level)
        {
            string path = "";
            if (level == 1)
            {
                path = FileConstants.HighPriorityFilePath;
            }
            else if (level == 2)
            {
                path = FileConstants.MediumPriorityFilePath;
            }
            else if (level == 3)
            {
                path = FileConstants.LowPriorityFilePath;
            }
            else if (level == 4)
            {
                path = FileConstants.CompletedFilePath;
            }

            return path;
        }

        [HttpGet]
        public JsonResult GetTasks(int level)
        {
            if (level == 4)
            {
                var Tasks = edit.convertToCompletedMdoel(ConvertLevelToPath(level));
                return Json(Tasks, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var Tasks = edit.convert(ConvertLevelToPath(level));
                return Json(Tasks, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult AddTask(string task, int level)
        {
            edit.add(ConvertLevelToPath(level), task);
            return GetTasks(level);
        }

        public JsonResult ClearTasks(int level)
        {
            edit.clear(ConvertLevelToPath(level));
            return GetTasks(level);
        } 

        public JsonResult RemoveTask(string task, int level)
        {
            edit.remove(ConvertLevelToPath(level), task);
            return GetTasks(level);
        }
    }
}