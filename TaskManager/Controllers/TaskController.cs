using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskManager.Models.Task task)
        {
            if(!ModelState.IsValid)
            {
                return View(task);
            }

            return View();
        }
    }
}
