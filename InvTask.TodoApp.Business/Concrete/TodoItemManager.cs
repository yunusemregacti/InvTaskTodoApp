using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using InvTask.TodoApp.Business.Abstract;
using InvTask.TodoApp.DataAccess.Abstract;
using InvTask.TodoApp.Entities.Concrete;

namespace InvTask.TodoApp.Business.Concrete
{
    public class TodoItemManager : ITodoItemService
    {
        private ITodoItemDal _todoItemDal;

        public TodoItemManager(ITodoItemDal todoItemDal)
        {
            _todoItemDal = todoItemDal;
        }

        public void AddItem(TodoItem toDo)
        {
            _todoItemDal.AddItem(toDo);
        }

        public void DeleteItem(Guid id)
        {
            _todoItemDal.DeleteItem(new TodoItem{Id = id,IsCompleted = true});
        }

        public IEnumerable<TodoItem> GetInCompleteItems()
        {
            return _todoItemDal.GetItems(t=>t.IsCompleted==false).ToList();
        }

        public void UpdateItem(TodoItem toDo)
        {
            _todoItemDal.UpdateItem(toDo);
        }
    }
}