using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.CQRS.ScheduleCQRS;
using AP.BoomTP.Application.CQRS.ScheduleStatusCQRS;
using AP.BoomTP.Application.CQRS.ScheduleTaskCQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AP.BoomTP.WebAPI.Controllers
{
    public class ScheduleTaskController : APIv1Controller
    {
        private readonly IMediator mediator;
        public ScheduleTaskController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("{scheduleId}")]
        public async Task<IActionResult> GetScheduleById(int scheduleId)
        {
            var scheduleTask = await mediator.Send(new GetScheduleTaskDetailQuery() { ScheduleId = scheduleId });
            if (scheduleTask == null)
                return NotFound();

            return Ok(scheduleTask);
        }

        [HttpPut]
        [Route("{scheduleId}/{taskId}/")]
        public async Task<IActionResult> UpdateSchedule(int scheduleId, int taskId, [FromBody] UpdateScheduleTaskCommand scheduleTask)
        {
            var scheduleTaskUpdate = await mediator.Send(new UpdateScheduleTaskCommand()
            {
                ScheduleId = scheduleId,
                TasksId = taskId,
                Status = scheduleTask.Status
            });

            if (scheduleTaskUpdate == null)
                return NotFound();

            return Ok(scheduleTaskUpdate);
        }

        [Route("{scheduleId}/{taskId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteScheduleTask(int scheduleId, int taskId)
        {
            var scheduleTask = await mediator.Send(new DeleteScheduleTaskCommand() { ScheduleId = scheduleId, TasksId = taskId});
            if (scheduleTask == null)
                return NotFound();

            return Ok(scheduleTask);
        }
    }
}
