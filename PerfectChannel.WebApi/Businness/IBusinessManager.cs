using System.Collections.Generic;
using PerfectChannel.WebApi.Models;

namespace PerfectChannel.WebApi.Business
{
    public interface IBusinessManager
    {
        public int AddTask(TaskModel task);
        public int UpdateTask(TaskModel task);
        public int DeleteTask(int idTask);
        public ICollection<TaskModel> GetAllTasks();
    }
}
