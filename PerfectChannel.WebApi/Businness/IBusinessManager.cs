using System.Collections.Generic;
using System.Threading.Tasks;
using PerfectChannel.WebApi.Models;

namespace PerfectChannel.WebApi.Business
{
    public interface IBusinessManager
    {
        public Task<ResultModel> AddTask(TaskModel task);
        public Task<ResultModel> UpdateTask(TaskModel task);
        public Task<ResultModel> DeleteTask(int idTask);
        public Task<ICollection<TaskModel>> GetAllTasks();
    }
}
