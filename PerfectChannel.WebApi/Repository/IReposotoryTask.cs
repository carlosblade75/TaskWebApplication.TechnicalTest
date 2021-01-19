using System.Collections.Generic;
using PerfectChannel.WebApi.Models;

namespace PerfectChannel.WebApi.Repository
{
    public interface IReposotoryTask
    {
        public TaskModel AddTask(TaskModel todo);
        public TaskModel UpdateTask(TaskModel todo);
        public TaskModel DeleteTask(TaskModel todo);
        public ICollection<TaskModel> GetAllTasks();
        public TaskModel GetTodoModelById(int id);
    }
}
