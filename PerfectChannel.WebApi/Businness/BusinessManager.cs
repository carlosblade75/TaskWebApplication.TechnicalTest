using System.Collections.Generic;
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

        public ResultModel AddTask(TaskModel task)
        {
            var result = new ResultModel { Success = true };

            if (!string.IsNullOrEmpty(task.Description))
            {
                task.IsCompleted = false;
                result.Task = _irepositoryTask.AddTask(task);
            }
            else
            {
                result.Success = false;
                result.MessageError = "Task description cannot be empty";
            }

            return result;
        }

        ///***** verificar que la tarea exista
        public ResultModel DeleteTask(int idTask)
        {
            var result = new ResultModel { Success = true };

            var taskToDelete = _irepositoryTask.GetTodoModelById(idTask);

            if (taskToDelete != null)
            {
                result.Task = _irepositoryTask.DeleteTask(taskToDelete);
            }
            else
            {
                result.Success = false;
                result.MessageError = "Task description cannot be found";
            }

            return result;
        }

        public ICollection<TaskModel> GetAllTasks()
        {
            return _irepositoryTask.GetAllTasks();
        }

        public ResultModel UpdateTask(TaskModel task)
        {
            var result = new ResultModel { Success = true };

            if (!string.IsNullOrEmpty(task.Description))
            {
                var taskToUpdate = _irepositoryTask.GetTodoModelById(task.Id);

                if (taskToUpdate != null)
                {
                    taskToUpdate.Description = task.Description;
                    taskToUpdate.IsCompleted = task.IsCompleted;
                    _irepositoryTask.UpdateTask(taskToUpdate);

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
