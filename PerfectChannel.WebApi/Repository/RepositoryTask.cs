using System.Collections.Generic;
using System.Linq;
using PerfectChannel.WebApi.Models;

namespace PerfectChannel.WebApi.Repository
{
    public class RepositoryTask : IReposotoryTask
    {
        private TaskContext _context;

        public RepositoryTask(TaskContext context)
        {
            _context = context;
        }

        public int AddTodo(TaskModel task)
        {
            _context.Tasks.Add(task);

            _context.SaveChanges();

            return task.Id;
        }

        public int DeleteTodo(TaskModel task)
        {
            _context.Tasks.Remove(task);

            _context.SaveChanges();

            return task.Id;
        }

        public ICollection<TaskModel> GetAllTasks()
        {
            return _context.Tasks.ToList();
        }

        public TaskModel GetTodoModelById(int id)
        {
            return _context.Tasks.Where(task => task.Id == id).SingleOrDefault();
        }

        public int UpdateTodo(TaskModel task)
        {
            _context.Tasks.Update(task);

            _context.SaveChanges();

            return task.Id;
        }
    }
}
