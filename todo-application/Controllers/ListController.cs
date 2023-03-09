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
    public class ListController : Controller
    {
        private readonly IRepository<ToDoList> toDoListRepository;

        public ListController(IRepository<ToDoList> toDoListRepository)
        {
            this.toDoListRepository = toDoListRepository ?? throw new ArgumentNullException(nameof(toDoListRepository));
        }

        [HttpPost("/lists")]
        public ActionResult CreateList(string listName)
        {
            toDoListRepository.Add(new ToDoList { Name = listName });

            return RedirectToRoutePermanent("AddedList", new { listName = listName });
        }

        [HttpPost]
        public ActionResult DeleteList(string listName)
        {
            var list = this.toDoListRepository.GetAll(null).First(x => x.Name == listName);
            this.toDoListRepository.Delete(list);

            return RedirectToAction("today", "home");
        }
    }
}