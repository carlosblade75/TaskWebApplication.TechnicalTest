using System.Collections.Generic;
using System.Threading.Tasks;
using PerfectChannel.WebApi.Models;
using PerfectChannel.WebApi.Repository;

namespace PerfectChannel.WebApi.Business
{
    public class BusinessManager : IBusinessManager
    {
        private IReposotoryTask _irepositoryTask;

        public BusinessManager(IReposotoryTask irepositoryTask)
        {
            _irepositoryTask = irepositoryTask;
        }

        public async Task<ResultModel> AddTask(TaskModel task)
        {
            var result = new ResultModel { Success = true };

            if (!string.IsNullOrEmpty(task.Description))
            {
                task.IsCompleted = false;
                result.Task = await _irepositoryTask.AddTaskAsync(task);
            }
            else
            {
                result.Success = false;
                result.MessageError = "Task description cannot be empty";
            }

            return result;
        }

        public async Task<ResultModel> DeleteTask(int idTask)
        {
            var result = new ResultModel { Success = true };

            var taskToDelete = await _irepositoryTask.GetTodoModelByIdAsync(idTask);

            if (taskToDelete != null)
            {
                result.Task = await _irepositoryTask.DeleteTaskAsync(taskToDelete);
            }
            else
            {
                result.Success = false;
                result.MessageError = "Task description cannot be found";
            }

            return result;
        }

        public async Task<ICollection<TaskModel>> GetAllTasks()
        {
            return await _irepositoryTask.GetAllTasksAsync();
        }

        public async Task<ResultModel> UpdateTask(TaskModel task)
        {
            var result = new ResultModel { Success = true };

            if (!string.IsNullOrEmpty(task.Description))
            {
                var taskToUpdate = await _irepositoryTask.GetTodoModelByIdAsync(task.Id);

                if (taskToUpdate != null)
                {
                    taskToUpdate.Description = task.Description;
                    taskToUpdate.IsCompleted = task.IsCompleted;
                    await _irepositoryTask.UpdateTaskAsync(taskToUpdate);

                    result.Task = taskToUpdate;
                }
                else
                {
                    result.Success = false;
                    result.MessageError = "Task description cannot be found";
                }
            }
            else
            {
                result.Success = false;
                result.MessageError = "Task description cannot be empty";
            }

            return result;
        }
    }
}
