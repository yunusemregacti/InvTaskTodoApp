using System;
using System.Collections.Generic;
using System.Text;
using InvTask.Core.DataAccess;
using InvTask.TodoApp.Entities.Concrete;

namespace InvTask.TodoApp.DataAccess.Abstract
{
    public interface ITodoItemDal:IEntityRepository<TodoItem>
    {
    }
}
