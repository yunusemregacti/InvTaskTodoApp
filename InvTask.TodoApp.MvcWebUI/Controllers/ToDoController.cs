using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvTask.TodoApp.Business.Abstract;
using InvTask.TodoApp.Entities.Concrete;
using InvTask.TodoApp.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvTask.TodoApp.MvcWebUI.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ITodoItemService _todoItemService;

        public ToDoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }


        public IActionResult Index()
        {
            var todoItems = _todoItemService.GetInCompleteItems();

            var model = new ToDoViewModel()
            {
                Items = todoItems,
                DueAt = todoItems.Where(i=>i.DueAtDateTime.DayOfYear == DateTime.Now.DayOfYear).ToList()
            };


            return View(model);
        }

        [ValidateAntiForgeryToken]
        public IActionResult AddItem(TodoItem todoItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            _todoItemService.AddItem(todoItem);

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public IActionResult UpdateItem(TodoItem todoItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            _todoItemService.UpdateItem(todoItem);

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(Guid id)
        {
            if (id==Guid.Empty)
            {
                return StatusCode(400);
            }

            _todoItemService.DeleteItem(id);

            return RedirectToAction("Index");
        }
    }
}