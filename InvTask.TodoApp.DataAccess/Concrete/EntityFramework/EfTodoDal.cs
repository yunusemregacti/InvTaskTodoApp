using System;
using System.Collections.Generic;
using System.Text;
using InvTask.Core.DataAccess.EntityFramework;
using InvTask.Core.DataAccess.InMemoryDB;
using InvTask.TodoApp.DataAccess.Abstract;
using InvTask.TodoApp.DataAccess.Concrete.InMemoryDB;
using InvTask.TodoApp.Entities.Concrete;

namespace InvTask.TodoApp.DataAccess.Concrete.EntityFramework
{
    public class EfTodoDal : EfEntityRepositoryBase<TodoItem, EfTodoContext>, ITodoItemDal
    {
    }
}
