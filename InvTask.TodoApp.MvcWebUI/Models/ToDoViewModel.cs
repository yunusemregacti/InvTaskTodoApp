using System.Collections.Generic;
using InvTask.TodoApp.Entities.Concrete;

namespace InvTask.TodoApp.MvcWebUI.Models
{
    public class ToDoViewModel
    {
        public IEnumerable<TodoItem> Items { get; set; }
    }
}