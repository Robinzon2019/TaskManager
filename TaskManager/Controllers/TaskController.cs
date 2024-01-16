using Microsoft.AspNetCore.Mvc;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            this._taskService = taskService;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _taskService.GetTasks();
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskManager.Models.Task task)
        {
            if(!ModelState.IsValid)
            {
                return View(task);
            }

            await _taskService.Create(task);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var task = await _taskService.GetTaskById(id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskManager.Models.Task task)
        {
            await _taskService.Edit(task);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var taskObtained = await _taskService.GetTaskById(id);

            if (taskObtained == null)
            {
                return NotFound();
            }

            await _taskService.Delete(taskObtained.Id);
            return RedirectToAction("Index");
        }
    }
}
