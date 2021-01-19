using NUnit.Framework;
using Moq;
using PerfectChannel.WebApi.Models;
using PerfectChannel.WebApi.Repository;
using PerfectChannel.WebApi.Business;

namespace PerfectChannel.WebApi.Test.Business
{
    [TestFixture]
    public class BusinessTesting
    {
        #region " Add Method "

        [Test]
        public void Business_AddTask_Success()
        {
            var respositoryMock = new Mock<IReposotoryTask>();

            var task = new TaskModel { Description = "First task" };

            respositoryMock.Setup(busi => busi.AddTask(It.IsAny<TaskModel>())).Returns(task);

            var business = new BusinessManager(respositoryMock.Object);

            var result = business.AddTask(task);

            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.MessageError == null);
            Assert.IsFalse(result.Task.IsCompleted);
        }

        [Test]
        public void Business_AddTask_No_Valid_Description_Empty()
        {
            var respositoryMock = new Mock<IReposotoryTask>();

            var task = new TaskModel { Description = string.Empty };

            respositoryMock.Setup(busi => busi.AddTask(It.IsAny<TaskModel>())).Returns(task);

            var business = new BusinessManager(respositoryMock.Object);

            var result = business.AddTask(task);

            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.MessageError == "Task description cannot be empty");
        }

        #endregion

        #region " Update Method "

        [Test]
        public void Business_UpdateTask_Success()
        {
            var respositoryMock = new Mock<IReposotoryTask>();

            var taskFromRepository = new TaskModel { Id= 1, Description = "First task", IsCompleted = false };

            var taskToUpdate = new TaskModel { Id = 1, Description = "First task", IsCompleted = true };

            respositoryMock.Setup(busi => busi.GetTodoModelById(It.IsAny<int>())).Returns(taskFromRepository);
            respositoryMock.Setup(busi => busi.UpdateTask(It.IsAny<TaskModel>())).Returns(taskToUpdate);

            var business = new BusinessManager(respositoryMock.Object);

            var result = business.UpdateTask(taskToUpdate);

            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.MessageError == null);
            Assert.IsTrue(result.Task.IsCompleted);
        }

        [Test]
        public void Business_UpdateTask_Task_No_Found()
        {
            var respositoryMock = new Mock<IReposotoryTask>();

            var task = new TaskModel { Id= 100, Description = "Task" };

            respositoryMock.Setup(busi => busi.GetTodoModelById(It.IsAny<int>())).Returns((TaskModel)null);

            var business = new BusinessManager(respositoryMock.Object);

            var result = business.UpdateTask(task);

            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.MessageError == "Task description cannot be found");
        }

        [Test]
        public void Business_UpdateTask_No_Valid_Description_Empty()
        {
            var respositoryMock = new Mock<IReposotoryTask>();

            var task = new TaskModel { Id = 1, Description = string.Empty };

            respositoryMock.Setup(busi => busi.GetTodoModelById(It.IsAny<int>())).Returns((TaskModel)null);

            var business = new BusinessManager(respositoryMock.Object);

            var result = business.UpdateTask(task);

            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.MessageError == "Task description cannot be empty");
        }

        #endregion

        #region " Delete Method "

        [Test]
        public void Business_DeleteTask_Success()
        {
            var respositoryMock = new Mock<IReposotoryTask>();

            var task = new TaskModel { Id= 1, Description = "First task" };

            respositoryMock.Setup(busi => busi.DeleteTask(It.IsAny<TaskModel>())).Returns(task);

            var business = new BusinessManager(respositoryMock.Object);

            var result = business.AddTask(task);

            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.MessageError == null);
        }

        [Test]
        public void Business_DeleteTask_Task_No_found()
        {
            var respositoryMock = new Mock<IReposotoryTask>();

            respositoryMock.Setup(busi => busi.DeleteTask(It.IsAny<TaskModel>())).Returns((TaskModel)null);

            var business = new BusinessManager(respositoryMock.Object);

            var result = business.DeleteTask(100);

            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.MessageError == "Task description cannot be found");
        }

        #endregion

    }
}
