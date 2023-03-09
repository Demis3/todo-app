using System;
using System.Collections.Generic;
using System.Linq;
using ToDoListLibrary.Data;
using ToDoListLibrary.Interfaces;
using ToDoListLibrary.Models;

#nullable enable
namespace ToDoListLibrary.Repositories
{
    /// <summary>
    /// Repository class that implements the <see cref="IRepository{TEntity}"/> interface for the <see cref="ToDoList"/> model.
    /// </summary>
    public class ToDoListRepository : IRepository<ToDoList>
    {
        private readonly ApplicationContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToDoListRepository"/> class.
        /// </summary>
        /// <param name="context">The <see cref="ToDoAppContext"/> object used to perform database operations.</param>
        public ToDoListRepository(ApplicationContext context)
        {
            _ = context ?? throw new ArgumentNullException(nameof(context));
            this.context = context;
        }

        /// <summary>
        /// Gets an <see cref="ToDoList"/> object from the database with a specified id.
        /// </summary>
        /// <param name="id">The identifier of the <see cref="ToDoList"/> object to be retrieved.</param>
        /// <returns>The <see cref="ToDoList"/> object with the specified id.</returns>
        public ToDoList GetById(int id)
        {
            return this.context.toDoLists.Find(id);
        }

        /// <summary>
        /// Gets a list of all <see cref="ToDoList"/> objects from the database.
        /// </summary>
        /// <returns>A list of all <see cref="ToDoList"/> objects in the database.</returns>
        public List<ToDoList> GetAll(string? listName)
        {
            return this.context.toDoLists.ToList();
        }

        /// <summary>
        /// Adds an <see cref="ToDoList"/> object to the database.
        /// </summary>
        /// <param name="toDoList">The <see cref="ToDoList"/> object to be added to the database.</param>
        public void Add(ToDoList toDoList)
        {
            _ = toDoList ?? throw new ArgumentNullException(nameof(toDoList));
            if (this.context.toDoLists.Any(x => x.Name == toDoList.Name)) return;

            this.context.toDoLists.Add(toDoList);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Updates an <see cref="ToDoList"/> object in the database.
        /// </summary>
        /// <param name="toDoList">The updated <see cref="ToDoList"/> object to be saved to the database.</param>
        public void Update(ToDoList toDoList)
        {
            _ = toDoList ?? throw new ArgumentNullException(nameof(toDoList));
            if (this.context.toDoLists.Any(x => x.Name == toDoList.Name)) return;

            this.context.toDoLists.Update(toDoList);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Deletes an <see cref="ToDoList"/> object from the database.
        /// </summary>
        /// <param name="toDoList">The <see cref="ToDoList"/> object to be deleted from the database.</param>
        public void Delete(ToDoList toDoList)
        {
            _ = toDoList ?? throw new ArgumentNullException(nameof(toDoList));

            var tasks = this.context.toDoTasks.Where(x => x.ListName == toDoList.Name);
            this.context.toDoTasks.RemoveRange(tasks);

            this.context.toDoLists.Remove(toDoList);
            this.context.SaveChanges();
        }
    }
}
