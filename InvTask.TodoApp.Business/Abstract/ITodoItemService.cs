using System;
using System.Collections.Generic;
using System.Text;
using InvTask.TodoApp.Entities.Concrete;

namespace InvTask.TodoApp.Business.Abstract
{
    public interface ITodoItemService
    {
        IEnumerable<TodoItem> GetInCompleteItems();
        void AddItem(TodoItem toDo);
        void UpdateItem(TodoItem toDo);
        void DeleteItem(Guid id);
    }
}
