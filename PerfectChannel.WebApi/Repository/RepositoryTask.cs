using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerfectChannel.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PerfectChannel.WebApi.Repository
{
    public class RepositoryTask : IReposotoryTask
    {
        private TaskContext _context;

        public RepositoryTask(TaskContext context)
        {
            _context = context;
        }

        public async Task<TaskModel> AddTaskAsync(TaskModel task)
        {
            task.Id = _context.Tasks.Count() + 1;

            _context.Tasks.Add(task);

            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<TaskModel> DeleteTaskAsync(TaskModel task)
        {
            _context.Tasks.Remove(task);

            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<ICollection<TaskModel>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskModel> GetTodoModelByIdAsync(int id)
        {
            return await _context.Tasks.Where(task => task.Id == id).SingleOrDefaultAsync();
        }

        public async Task<TaskModel> UpdateTaskAsync(TaskModel task)
        {
            _context.Tasks.Update(task);

            await _context.SaveChangesAsync();

            return task;
        }
        
    }
}
