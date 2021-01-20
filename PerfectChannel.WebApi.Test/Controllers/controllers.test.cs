using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Moq;
using PerfectChannel.WebApi.Controllers;
using PerfectChannel.WebApi.Business;
using PerfectChannel.WebApi.Models;
using System.Threading.Tasks;

namespace PerfectChannel.WebApi.Test.Controllers
{
    [TestFixture]
    public class ControllerTesting
    {
        private TaskController _controller;

        private const int STATUS_OK = 200;
        private const int STATUS_NOFOUND = 404;
        private const int STATUS_BADREQUEST = 400;

        #region " Add Method "

        [Test]
        public async Task Controller_AddTask_Ok_Success()
        {
            var businessMock = new Mock<IBusinessManager>();

            var resultModel = new ResultModel { Success = true, Task = new TaskModel {Description = "First task"}, MessageError = string.Empty};

            businessMock.Setup(busi => busi.AddTask(It.IsAny<TaskModel>())).ReturnsAsync(resultModel);

            _controller = new TaskController(businessMock.Object);

            var result = await _controller.AddTask(resultModel.Task) as OkObjectResult;

            Assert.AreEqual(result.StatusCode, STATUS_OK);
            Assert.AreEqual((result.Value as ResultModel).Success, true);
        }

        [Test]
        public async Task Controller_AddTask_No_Description_OK_No_Success()
        {
            var businessMock = new Mock<IBusinessManager>();

            var task = new TaskModel();

            var resultModel = new ResultModel { Success = false, Task = task, MessageError = "Error Validation" };

            businessMock.Setup(busi => busi.AddTask(It.IsAny<TaskModel>())).ReturnsAsync(resultModel);

            _controller = new TaskController(businessMock.Object);

            var result = await _controller.AddTask(task) as OkObjectResult;

            Assert.AreEqual(result.StatusCode, STATUS_OK);
        }

        [Test]
        public async Task Controller_AddTask_Exception_BadRequest()
        {
            var businessMock = new Mock<IBusinessManager>();

            var newModelToAdd = new TaskModel
            {
                Description = "First task"
            };

            businessMock.Setup(busi => busi.AddTask(It.IsAny<TaskModel>())).ThrowsAsync(new System.Exception());

            _controller = new TaskController(businessMock.Object);

            var result = await _controller.AddTask(newModelToAdd) as BadRequestResult;

            Assert.AreEqual(result.StatusCode, STATUS_BADREQUEST);
        }

        #endregion

        #region " Update Method "

        [Test]
        public async Task Controller_UpdateTask_OK()
        {
            var businessMock = new Mock<IBusinessManager>();

            var resultModel = new ResultModel { Success = true, Task = new TaskModel(), MessageError = string.Empty };

            businessMock.Setup(busi => busi.UpdateTask(It.IsAny<TaskModel>())).ReturnsAsync(resultModel);

            _controller = new TaskController(businessMock.Object);

            var result = await _controller.UpdateTask(resultModel.Task) as OkObjectResult;

            Assert.AreEqual(result.StatusCode, STATUS_OK);
            Assert.AreEqual((result.Value as ResultModel).Success, true);
        }

        [Test]
        public async Task Controller_UpdateTask_NoFound()
        {
            var businessMock = new Mock<IBusinessManager>();

            var resultModel = new ResultModel { Success = false, Task = null, MessageError = string.Empty };

            businessMock.Setup(busi => busi.UpdateTask(It.IsAny<TaskModel>())).ReturnsAsync(resultModel);

            _controller = new TaskController(businessMock.Object);

            var result = await _controller.UpdateTask(resultModel.Task) as NotFoundResult;

            Assert.AreEqual(result.StatusCode, STATUS_NOFOUND);
        }

        [Test]
        public async Task Controller_UpdateTask_No_Description_OK_No_Success()
        {
            var businessMock = new Mock<IBusinessManager>();

            var resultModel = new ResultModel { Success = false, Task = new TaskModel(), MessageError = "Error Validation" };

            businessMock.Setup(busi => busi.UpdateTask(It.IsAny<TaskModel>())).ReturnsAsync(resultModel);

            _controller = new TaskController(businessMock.Object);

            var result = await _controller.UpdateTask(resultModel.Task) as OkObjectResult;

            Assert.AreEqual(result.StatusCode, STATUS_OK);
        }

        [Test]
        public async Task Controller_UpdateTask_Exception_BadRequest()
        {
            var businessMock = new Mock<IBusinessManager>();

            var resultModel = new ResultModel { Success = false, Task = new TaskModel(), MessageError = "Error" };

            businessMock.Setup(busi => busi.UpdateTask(It.IsAny<TaskModel>())).ThrowsAsync(new System.Exception());

            _controller = new TaskController(businessMock.Object);

            var result = await _controller.UpdateTask(resultModel.Task) as BadRequestResult;

            Assert.AreEqual(result.StatusCode, STATUS_BADREQUEST);
        }

        #endregion

        #region " Delete Method "

        [Test]
        public async Task Controller_DeleteTask_Ok()
        {
            var businessMock = new Mock<IBusinessManager>();

            var resultModel = new ResultModel { Success = true, Task = new TaskModel { Description = "First task" }, MessageError = string.Empty };

            businessMock.Setup(busi => busi.DeleteTask(It.IsAny<int>())).ReturnsAsync(resultModel);

            _controller = new TaskController(businessMock.Object);

            var result = await _controller.DeleteTask(1) as OkObjectResult;

            Assert.AreEqual(result.StatusCode, STATUS_OK);
            Assert.AreEqual((result.Value as ResultModel).Success, true);
        }

        [Test]
        public async Task Controller_DeleteTask_NoFound()
        {
            var businessMock = new Mock<IBusinessManager>();

            var resultModel = new ResultModel { Success = false, Task = null, MessageError = string.Empty };

            businessMock.Setup(busi => busi.DeleteTask(It.IsAny<int>())).ReturnsAsync(resultModel);

            _controller = new TaskController(businessMock.Object);

            var result = await _controller.DeleteTask(1) as NotFoundResult;

            Assert.AreEqual(result.StatusCode, STATUS_NOFOUND);
        }

        [Test]
        public async Task Controller_DeleteTask_Exception_BadRequest()
        {
            var businessMock = new Mock<IBusinessManager>();

            var resultModel = new ResultModel { Success = true, Task = new TaskModel(), MessageError = string.Empty };

            businessMock.Setup(busi => busi.DeleteTask(It.IsAny<int>())).ThrowsAsync(new System.Exception());

            _controller = new TaskController(businessMock.Object);

            var result = await _controller.DeleteTask(1) as BadRequestResult;

            Assert.AreEqual(result.StatusCode, STATUS_BADREQUEST);
        }

        #endregion
    }
}