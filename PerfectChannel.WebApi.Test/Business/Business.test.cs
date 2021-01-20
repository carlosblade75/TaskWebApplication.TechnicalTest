using NUnit.Framework;
using Moq;
using PerfectChannel.WebApi.Models;
using PerfectChannel.WebApi.Repository;
using PerfectChannel.WebApi.Business;
using System.Threading.Tasks;

namespace PerfectChannel.WebApi.Test.Business
{
    [TestFixture]
    public class BusinessTesting
    {
        #region " Add Method "

        [Test]
        public async Task Business_AddTask_Success()
        {
            var respositoryMock = new Mock<IReposotoryTask>();

            var task = new TaskModel { Description = "First task" };

            respositoryMock.Setup(busi => busi.AddTaskAsync(It.IsAny<TaskModel>())).ReturnsAsync(task);

            var business = new BusinessManager(respositoryMock.Object);

            var result = await business.AddTask(task);

            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.MessageError == null);
            Assert.IsFalse(result.Task.IsCompleted);
        }

        [Test]
        public async Task Business_AddTask_No_Valid_Description_Empty()
        {
            var respositoryMock = new Mock<IReposotoryTask>();

            var task = new TaskModel { Description = string.Empty };

            respositoryMock.Setup(busi => busi.AddTaskAsync(It.IsAny<TaskModel>())).ReturnsAsync(task);

            var business = new BusinessManager(respositoryMock.Object);

            var result = await business.AddTask(task);

            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.MessageError == "Task description cannot be empty");
        }

        #endregion

        #region " Update Method "

        [Test]
        public async Task Business_UpdateTask_Success()
        {
            var respositoryMock = new Mock<IReposotoryTask>();

            var taskFromRepository = new TaskModel { Id= 1, Description = "First task", IsCompleted = false };

            var taskToUpdate = new TaskModel { Id = 1, Description = "First task", IsCompleted = true };

            respositoryMock.Setup(busi => busi.GetTodoModelByIdAsync(It.IsAny<int>())).ReturnsAsync(taskFromRepository);
            respositoryMock.Setup(busi => busi.UpdateTaskAsync(It.IsAny<TaskModel>())).ReturnsAsync(taskToUpdate);

            var business = new BusinessManager(respositoryMock.Object);

            var result = await business.UpdateTask(taskToUpdate);

            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.MessageError == null);
            Assert.IsTrue(result.Task.IsCompleted);
        }

        [Test]
        public async Task Business_UpdateTask_Task_No_Found()
        {
            var respositoryMock = new Mock<IReposotoryTask>();

            var task = new TaskModel { Id= 100, Description = "Task" };

            respositoryMock.Setup(busi => busi.GetTodoModelByIdAsync(It.IsAny<int>())).ReturnsAsync((TaskModel)null);

            var business = new BusinessManager(respositoryMock.Object);

            var result = await business.UpdateTask(task);

            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.MessageError == "Task description cannot be found");
        }

        [Test]
        public async Task Business_UpdateTask_No_Valid_Description_Empty()
        {
            var respositoryMock = new Mock<IReposotoryTask>();

            var task = new TaskModel { Id = 1, Description = string.Empty };

            respositoryMock.Setup(busi => busi.GetTodoModelByIdAsync(It.IsAny<int>())).ReturnsAsync((TaskModel)null);

            var business = new BusinessManager(respositoryMock.Object);

            var result = await business.UpdateTask(task);

            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.MessageError == "Task description cannot be empty");
        }

        #endregion

        #region " Delete Method "

        [Test]
        public async Task Business_DeleteTask_Success()
        {
            var respositoryMock = new Mock<IReposotoryTask>();

            var task = new TaskModel { Id= 1, Description = "First task" };

            respositoryMock.Setup(busi => busi.DeleteTaskAsync(It.IsAny<TaskModel>())).ReturnsAsync(task);

            var business = new BusinessManager(respositoryMock.Object);

            var result = await business.AddTask(task);

            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.MessageError == null);
        }

        [Test]
        public async Task Business_DeleteTask_Task_No_found()
        {
            var respositoryMock = new Mock<IReposotoryTask>();

            respositoryMock.Setup(busi => busi.DeleteTaskAsync(It.IsAny<TaskModel>())).ReturnsAsync((TaskModel)null);

            var business = new BusinessManager(respositoryMock.Object);

            var result = await business.DeleteTask(100);

            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.MessageError == "Task description cannot be found");
        }

        #endregion

    }
}
