using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using InvTask.Core.Entities;

namespace InvTask.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        IEnumerable<T> GetItems(Expression<Func<T, bool>> filter = null);

        //List<T> GetList(Expression<Func<T,bool>> filter=null);
        void AddItem(T entity);
        void UpdateItem(T entity);
        void DeleteItem(T entity);
    }
}
