using AP.BoomTP.Application.CQRS.TasksCQRS;
using AP.BoomTP.Application.CQRS.UserCQRS;
using AP.BoomTP.Application.CQRS.ZoneCQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AP.BoomTP.WebAPI.Controllers
{
    public class TasksController : APIv1Controller
    {
        private readonly IMediator mediator;

        public TasksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(await mediator.Send(new GetAllTasksQuery() { pageNr = pageNr, pageSize = pageSize }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTasks([FromBody] CreateTasksCommand task)
        {
            return Created("", await mediator.Send(task));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {

            var zone = await mediator.Send(new GetTaskByIdQuery() { Id = id });
            if (zone == null)
                return NotFound();

            return Ok(zone);
        }


        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var taskD = await mediator.Send(new DeleteTasksCommand() { Id = id });
            if (taskD == null)
                return NotFound();

            return Ok(taskD);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTasks(int id, [FromBody] UpdateTasksCommand task)
        {
            var taskUpdate = await mediator.Send(new UpdateTasksCommand() { Title = task.Title, Description = task.Description, TaskTime = task.TaskTime, Id = id});
            if (taskUpdate == null)
                return NotFound();

            return Ok(taskUpdate);

        }
    }
}
