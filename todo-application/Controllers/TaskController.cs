using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using todo_application.Models;
using ToDoListLibrary.Interfaces;
using ToDoListLibrary.Models;

namespace todo_application.Controllers
{
    public class TaskController : Controller
    {
        private readonly IRepository<ToDoTask> toDoTaskRepository;

        public TaskController(IRepository<ToDoTask> toDoTaskRepository)
        {
            this.toDoTaskRepository = toDoTaskRepository ?? throw new ArgumentNullException(nameof(toDoTaskRepository));
        }

        [HttpPost("/tasks")]
        public ActionResult CreateTask(string title, string description)
        {
            string route;

            if (TempData.ContainsKey("prevRoute"))
                route = TempData["prevRoute"].ToString();
            else
                throw new ArgumentException("TempData no saved route");

            var task = new ToDoTask { CreationDate = DateTime.Now, ListName = route, Title = title, Description = description };
            toDoTaskRepository.Add(task);

            if (route == "today" || route == "important" || route == "plans" || route == "personal")
                return RedirectToAction(route, "home");
            else
                return RedirectToRoutePermanent("AddedList", new { listName = route });
        }

        [HttpPost("/status")]
        public ActionResult Status(int id, string listName, IFormCollection form, string title, string description, DateTime dueDate)
        {
            string route;

            if (TempData.ContainsKey("prevRoute"))
                route = TempData["prevRoute"].ToString();
            else
                throw new ArgumentException("TempData no saved route");

            var task =  toDoTaskRepository.GetAll(listName).Find(x => x.Id == id && x.Title==title && x.Description==description);

            switch (form["submitButton"])
            {
                case "Done":
                    task.IsCompleted ^= true;
                    toDoTaskRepository.Update(task);
                    break;
                case "Confirm":
                    task.Title = title;
                    task.Description = description;
                    if (dueDate.Date != new DateTime(01, 01, 01))
                    {
                        task.DueDate = dueDate;
                    }
                    toDoTaskRepository.Update(task);
                    break;
                case "Remove":
                    toDoTaskRepository.Delete(task);
                    break;
            }

            if (route == "today" || route == "important" || route == "plans" || route == "personal")
                return RedirectToAction(route, "home");
            else
                return RedirectToRoutePermanent("AddedList", new { listName = listName });
        }
    }
}