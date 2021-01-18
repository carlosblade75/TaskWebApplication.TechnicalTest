using Microsoft.EntityFrameworkCore;
using PerfectChannel.WebApi.Models;

namespace PerfectChannel.WebApi.Repository
{
    public class TaskContext: DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options): base(options)
        {
        }

        public DbSet<TaskModel> Tasks { get; set; }
    }
}
