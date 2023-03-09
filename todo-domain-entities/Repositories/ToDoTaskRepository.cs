using System;
using System.Collections.Generic;
using System.Linq;
using ToDoListLibrary.Data;
using ToDoListLibrary.Interfaces;
using ToDoListLibrary.Models;

namespace ToDoListLibrary.Repositories
{
    /// <summary>
    /// Repository class that implements the <see cref="IRepository{TEntity}"/> interface for the <see cref="Entry"/> model.
    /// </summary>
    public class ToDoTaskRepository : IRepository<ToDoTask>
    {
        private readonly ApplicationContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToDoTaskRepository"/> class.
        /// </summary>
        /// <param name="context">The <see cref="ToDoAppContext"/> object used to perform database operations.</param>
        public ToDoTaskRepository(ApplicationContext context)
        {
            _ = context ?? throw new ArgumentNullException(nameof(context));
            this.context = context;
        }

        /// <summary>
        /// Gets an <see cref="Entry"/> object from the database with a specified id.
        /// </summary>
        /// <param name="id">The identifier of the <see cref="Entry"/> object to be retrieved.</param>
        /// <returns>The <see cref="Entry"/> object with the specified id.</returns>
        public ToDoTask GetById(int id)
        {
            return this.context.toDoTasks.Find(id);
        }

        /// <summary>
        /// Gets a list of all <see cref="Entry"/> objects from the database.
        /// </summary>
        /// <returns>A list of all <see cref="Entry"/> objects in the database.</returns>
        public List<ToDoTask> GetAll(string listName)
        {
            return this.context.toDoTasks.Where(x => x.ListName == listName).ToList();
        }

        /// <summary>
        /// Adds an <see cref="Entry"/> object to the database.
        /// </summary>
        /// <param name="entry">The <see cref="Entry"/> object to be added to the database.</param>
        public void Add(ToDoTask task)
        {
            _ = task ?? throw new ArgumentNullException(nameof(task));
            if (task.Title == null) return;

            this.context.toDoTasks.Add(task);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Updates an <see cref="Entry"/> object in the database.
        /// </summary>
        /// <param name="entry">The updated <see cref="Entry"/> object to be saved to the database.</param>
        public void Update(ToDoTask task)
        {
            _ = task ?? throw new ArgumentNullException(nameof(task));

            this.context.toDoTasks.Update(task);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Deletes an <see cref="Entry"/> object from the database.
        /// </summary>
        /// <param name="entry">The <see cref="Entry"/> object to be deleted from the database.</param>
        public void Delete(ToDoTask task)
        {
            _ = task ?? throw new ArgumentNullException(nameof(task));

            this.context.toDoTasks.Remove(task);
            this.context.SaveChanges();
        }
    }
}
