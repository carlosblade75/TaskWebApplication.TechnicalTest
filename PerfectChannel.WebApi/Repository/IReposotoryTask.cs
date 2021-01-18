using System.Collections.Generic;
using PerfectChannel.WebApi.Models;

namespace PerfectChannel.WebApi.Repository
{
    public interface IReposotoryTask
    {
        public int AddTodo(TaskModel todo);
        public int UpdateTodo(TaskModel todo);
        public int DeleteTodo(TaskModel todo);
        public ICollection<TaskModel> GetAllTasks();
        public TaskModel GetTodoModelById(int id);
    }
}
