using Microsoft.EntityFrameworkCore;
using TaskManager.Data;

namespace TaskManager.Services
{
    public interface ITaskService
    {
        Task<List<Models.Task>> GetTasks();
        Task Create(Models.Task task);
        Task Edit(Models.Task task);
        Task Delete(int id);
        Task<Models.Task> GetTaskById(int id);
    }

    public class TaskService: ITaskService
    {
        private readonly AppDbContext _appDbContext;

        public TaskService(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<List<TaskManager.Models.Task>> GetTasks()
        {
            List<TaskManager.Models.Task> tasks = new List<TaskManager.Models.Task>();

            try
            {
                tasks = await _appDbContext.Tasks.ToListAsync();
            }
            catch (Exception ex) 
            {
                throw ex;
            }

            return tasks;
        }

        public async Task Create(TaskManager.Models.Task task) {
            try
            {
                await _appDbContext.Tasks.AddAsync(task);
                await _appDbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public async Task Edit(TaskManager.Models.Task task)
        {
            try
            {

                var taskObtained = await this.GetTaskById(task.Id);

                if (taskObtained != null)
                {
                    taskObtained.Descripcion = task.Descripcion;
                    taskObtained.FechaCreacion = task.FechaCreacion;
                    taskObtained.Estado = task.Estado;
                    taskObtained.Prioridad = task.Prioridad;
                    await _appDbContext.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var task = await _appDbContext.Tasks.FindAsync(id);

                if(task != null)
                {
                    _appDbContext.Tasks.Remove(task);
                    await _appDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TaskManager.Models.Task> GetTaskById(int id)
        {
            TaskManager.Models.Task task = new TaskManager.Models.Task();

            try
            {
                task = await _appDbContext.Tasks.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return task;
        }
    }
}
