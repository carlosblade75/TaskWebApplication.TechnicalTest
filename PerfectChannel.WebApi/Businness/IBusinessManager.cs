using System.Collections.Generic;
using PerfectChannel.WebApi.Models;

namespace PerfectChannel.WebApi.Business
{
    public interface IBusinessManager
    {
        public ResultModel AddTask(TaskModel task);
        public ResultModel UpdateTask(TaskModel task);
        public ResultModel DeleteTask(int idTask);
        public ICollection<TaskModel> GetAllTasks();
    }
}
