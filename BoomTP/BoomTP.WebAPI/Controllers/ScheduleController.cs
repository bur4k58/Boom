using AP.BoomTP.Application.CQRS.ScheduleCQRS;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AP.BoomTP.WebAPI.Controllers
{
    public class ScheduleController : APIv1Controller
    {
        private readonly IMediator mediator;
        public ScheduleController(IMediator mediator)
        {
            this.mediator = mediator;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllSchedule([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 10)
        {
            return Ok(await mediator.Send(new GetAllScheduleQuery { pageNr = pageNr, pageSize = pageSize }));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetScheduleByIdQuery(int id)
        {
            var schedule = await mediator.Send(new GetScheduleByIdQuery() { Id = id });
            if (schedule == null)
                return NotFound();

            return Ok(schedule);
        }

        [HttpGet]
        [Route("getbyuserid/{userid}")]
        public async Task<IActionResult> GetAllScheduleByUserId(int userid)
        {
            var schedule = await mediator.Send(new GetAllScheduleByUserId() { Id = userid });
            if (schedule == null)
                return NotFound();

            return Ok(schedule);
        }

        [HttpGet]
        [Route("getthisweekbyuserid/{userid}")]
        public async Task<IActionResult> GetScheduleThisWeek(int userid)
        {
            var schedule = await mediator.Send(new GetScheduleThisWeek() { Id = userid });
            if (schedule == null)
                return NotFound();

            return Ok(schedule);
        }

        [HttpGet]
        [Route("getbehindschedule")]
        public async Task<IActionResult> GetBehindSchedule([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 10)
        {
            var schedule = await mediator.Send(new GetBehindScheduleQuery() { pageNr = pageNr, pageSize = pageSize });
            if (schedule == null)
                return NotFound();

            return Ok(schedule);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchedule([FromBody] CreateScheduleCommand schedule)
        {
            return Created("", await mediator.Send(schedule));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateSchedule(int id, [FromBody] UpdateScheduleCommand schedule)
        {
            var scheduleUpdate = await mediator.Send(new UpdateScheduleCommand() {
                Id = id,
                Date = schedule.Date,
                UserId = schedule.UserId,
                ZoneId = schedule.ZoneId,
                TaskId = schedule.TaskId
            });

            if (scheduleUpdate == null)
                return NotFound();

            return Ok(scheduleUpdate);

        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var schedule = await mediator.Send(new DeleteScheduleCommand() { Id = id });
            if (schedule == null)
                return NotFound();

            return Ok(schedule);
        }
    }
}
