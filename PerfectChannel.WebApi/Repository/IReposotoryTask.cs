using System.Collections.Generic;
using System.Threading.Tasks;
using PerfectChannel.WebApi.Models;

namespace PerfectChannel.WebApi.Repository
{
    public interface IReposotoryTask
    {
        public Task<TaskModel> AddTaskAsync(TaskModel todo);
        public Task<TaskModel> UpdateTaskAsync(TaskModel todo);
        public Task<TaskModel> DeleteTaskAsync(TaskModel todo);
        public Task<ICollection<TaskModel>> GetAllTasksAsync();
        public Task<TaskModel> GetTodoModelByIdAsync(int id);
    }
}
