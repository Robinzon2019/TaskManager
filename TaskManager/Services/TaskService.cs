using Microsoft.EntityFrameworkCore;
using TaskManager.Data;

namespace TaskManager.Services
{
    interface ITaskService
    {

    }

    public class TaskService: ITaskService
    {
        private readonly AppDbContext _appDbContext;

        public TaskService(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<List<TaskManager.Models.Task>> GetTask()
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
                _appDbContext.Tasks.Update(task);
                await _appDbContext.SaveChangesAsync();
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
    }
}
