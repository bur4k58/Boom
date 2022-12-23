using AP.BoomTP.Application.CQRS.ScheduleCQRS;
using AP.BoomTP.Application.CQRS.ScheduleStatusCQRS;
using AP.BoomTP.Application.Exceptions;
using AP.BoomTP.Application.Interfaces;
using AP.BoomTP.Domain;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Status = AP.BoomTP.Domain.Status;

namespace AP.BoomTP.Application.CQRS.ScheduleTaskCQRS
{
    public class UpdateScheduleTaskCommand : IRequest<ScheduleTaskDTO>
    {
        public int? ScheduleId { get; set; }
        public int? TasksId { get; set; }
        public Status Status { get; set; }
    }
    public class UpdateScheduleTaskValidator : AbstractValidator<UpdateScheduleTaskCommand>
    {
        public UpdateScheduleTaskValidator()
        {
            RuleFor(x => x.ScheduleId).NotEmpty().WithMessage("ScheduleId can not be null");
            RuleFor(x => x.TasksId).NotEmpty().WithMessage("TaskId can not be null");
        }
    }
    public class UpdateScheduleTaskCommandHandler : IRequestHandler<UpdateScheduleTaskCommand, ScheduleTaskDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public UpdateScheduleTaskCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<ScheduleTaskDTO> Handle(UpdateScheduleTaskCommand request, CancellationToken cancellationToken)
        {
            ScheduleTask scheduleTask = await uow.ScheduleTaskRepository.GetByScheduleIdAndTaskId(request.ScheduleId.Value, request.TasksId.Value);

            if (scheduleTask.Status == Status.Made)
            {
                scheduleTask.Status = request.Status;
            }
            else if (scheduleTask.Status == Status.Start && request.Status == Status.Ended)
            {
                scheduleTask.Status = request.Status;
            }
            else if (scheduleTask.Status == Status.Start && request.Status == Status.Made)
            {
                throw new ScheduleTaskException("Een taak kan slechts 1x gestart worden.");
            }
            else if (scheduleTask.Status == Status.Ended && (request.Status == Status.Made || request.Status == Status.Start))
            {
                throw new ScheduleTaskException("Een taak die afgehandeld werd kan niet opnieuw gestart worden.");
            }
            else
            {
                scheduleTask.Status = request.Status;
            }

            uow.ScheduleTaskRepository.Update(scheduleTask);
            await uow.Commit();

            return mapper.Map<ScheduleTaskDTO>(scheduleTask);
        }
    }
}