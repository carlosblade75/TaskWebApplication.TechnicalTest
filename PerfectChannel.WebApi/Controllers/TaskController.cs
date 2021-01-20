using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAllTasks()
        {
            IEnumerable<TaskModel> list;

            try
            {
                list = await _business.GetAllTasks();
            }
            catch
            {
                return NotFound();
            } 

            return Ok(list);
        }

        [HttpPut]
        public async Task<IActionResult> AddTask(TaskModel model)
        {
            ResultModel result;

            try
            {
                result = await _business.AddTask(model);

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
        public async Task<IActionResult> UpdateTask(TaskModel model)
        {
            ResultModel result;

            try
            {
                result = await _business.UpdateTask(model);

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
        public async Task<IActionResult> DeleteTask(int idTask)
        {
            ResultModel result;

            try
            {
                result = await _business.DeleteTask(idTask);

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