using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using InvTask.Core.Entities;

namespace InvTask.TodoApp.Entities.Concrete
{
    public class TodoItem:IEntity
    {
        public Guid Id { get; set; }
        public bool IsCompleted { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime DueAtDateTime { get; set; }
    }
}