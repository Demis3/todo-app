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
    public class HomeController : Controller
    {
        private readonly IRepository<ToDoTask> toDoTaskRepository;

        public HomeController(IRepository<ToDoTask> toDoTaskRepository)
        {
            this.toDoTaskRepository = toDoTaskRepository ?? throw new ArgumentNullException(nameof(toDoTaskRepository));
        }

        [HttpGet("/")]
        public ActionResult Index() => RedirectToAction("today");

        [HttpGet("/today")]
        public ActionResult Today() => ListView();

        [HttpGet("/important")]
        public ActionResult Important() => ListView();

        [HttpGet("/personal")]
        public ActionResult Personal() => ListView();

        [HttpGet("/plans")]
        public ActionResult Plans() => ListView();

        [Route("{listName}")]
        public ActionResult AddedList(string listName) => ListView(listName);

        //---------------------------

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        private ActionResult ListView(string listName = null)
        {
            var req = listName;
            if (req == null)
            {
                req = Request.Path.Value.Split('/').Last();
            }
            TempData["prevRoute"] = req;
            List<ToDoTask> allTasks = this.toDoTaskRepository.GetAll(req);
            TempData.Keep("prevRoute");
            return View(allTasks);
        }
    }
}
