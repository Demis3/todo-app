using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListLibrary.Models
{
    public class ToDoTask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string ListName { get; set; }
    }
}
