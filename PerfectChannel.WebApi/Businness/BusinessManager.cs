using System.Collections.Generic;
using PerfectChannel.WebApi.Models;
using PerfectChannel.WebApi.Repository;

namespace PerfectChannel.WebApi.Business
{
    public class BusinessManager : IBusinessManager
    {
        private IReposotoryTask _irepositoryTodo;
        public BusinessManager(IReposotoryTask irepositoryTodo)
        {
            _irepositoryTodo = irepositoryTodo;
        }

        public int AddTask(TaskModel task)
        {
            task.IsCompleted = false;

            return _irepositoryTodo.AddTodo(task);
        }

        public int DeleteTask(int idTask)
        {
            var todoToDelete = _irepositoryTodo.GetTodoModelById(idTask);

            return _irepositoryTodo.DeleteTodo(todoToDelete);
        }

        public ICollection<TaskModel> GetAllTasks()
        {
            return _irepositoryTodo.GetAllTasks();
        }

        public int UpdateTask(TaskModel todo)
        {
            var todoToUpdate = _irepositoryTodo.GetTodoModelById(todo.Id);

            todoToUpdate.Description = todo.Description;
            todoToUpdate.IsCompleted = todo.IsCompleted;

            return _irepositoryTodo.UpdateTodo(todoToUpdate);
        }
    }
}
