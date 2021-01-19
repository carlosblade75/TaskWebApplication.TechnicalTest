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
            IEnumerable<TaskModel> list;

            try
            {
                list = _business.GetAllTasks();
            }
            catch
            {
                return NotFound();
            } 

            return Ok(list);
        }

        [HttpPut]
        public IActionResult AddTask(TaskModel model)
        {
            ResultModel result;

            try
            {
                result = _business.AddTask(model);

                if (!result.Success)
                {
                    return Ok(result);
                }
            }
            catch
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult UpdateTask(TaskModel model)
        {
            ResultModel result;

            try
            {
                result = _business.UpdateTask(model);

                if (!result.Success && result.Task == null)
                {
                    return NotFound();
                } 
                
                if (!result.Success)
                {
                    return Ok(result);
                }
            }
            catch
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteTask(int idTask)
        {
            ResultModel result;

            try
            {
                result = _business.DeleteTask(idTask);

                if (!result.Success && result.Task == null)
                {
                    return NotFound();
                }

                if (!result.Success)
                {
                    return Ok(result);
                }
            }
            catch
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}