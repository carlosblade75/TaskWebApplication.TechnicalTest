using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PerfectChannel.WebApi.Business;
using PerfectChannel.WebApi.Models;

namespace PerfectChannel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private IBusinessManager _business;

        public TaskController(IBusinessManager business)
        {
            _business = business;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            IEnumerable<TaskModel> list = null;

            try
            {
                list = _business.GetAllTasks();
            }
            catch(Exception ex)
            {
                return NotFound();
            } 

            return Ok(list);
        }

        [HttpPut]
        public int AddTask(TaskModel model)
        {
            return _business.AddTask(model);
        }

        [HttpPost]
        public int UpdateTask(TaskModel model)
        {
            return _business.UpdateTask(model);
        }
    }
}