using System;
using System.Collections.Generic;
using System.Text;
using InvTask.TodoApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace InvTask.TodoApp.DataAccess.Concrete.EntityFramework
{
    public class EfTodoContext : DbContext
    {
        public EfTodoContext()
        {
            
        }
        public EfTodoContext(DbContextOptions<EfTodoContext> options):base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EFTodoDB;Trusted_Connection=True;",b=>b.MigrationsAssembly("InvTask.TodoApp.MvcWebUI"));
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
