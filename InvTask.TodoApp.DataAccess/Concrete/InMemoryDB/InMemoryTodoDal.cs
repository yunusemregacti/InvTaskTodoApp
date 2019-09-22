using System;
using System.Collections.Generic;
using System.Text;
using InvTask.Core.DataAccess.InMemoryDB;
using InvTask.TodoApp.DataAccess.Abstract;
using InvTask.TodoApp.Entities.Concrete;

namespace InvTask.TodoApp.DataAccess.Concrete.InMemoryDB
{
    public class InMemoryTodoDal:InMemoryRepositoryBase<TodoItem,TodoContext>,ITodoItemDal
    {

    }
}