using System.Linq;
using Microsoft.AspNet.Mvc;
using ToDoList.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Controllers
{
    public class TodoController : Controller
    {
        private readonly ToDoContext _ctx;

        public TodoController(ToDoContext ctx)
        {
            _ctx = ctx;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(new ToDoModel(_ctx.ToDoItems));
        }

        [HttpPost]
        public IActionResult NewToDoItem(ToDoModel model)
        {
            _ctx.Add(new ToDoItem { Task = model.NewItemName });
            _ctx.SaveChanges();
            return Redirect("/");
        }

        [HttpPost]
        public IActionResult ToggleCompleted(int id)
        {
            var item = _ctx.ToDoItems.SingleOrDefault(i => i.Id == id);

            if (item != null)
            {
                item.Completed = !item.Completed;
                _ctx.SaveChanges();
            }

            return Redirect("/");
        }

    }
}
