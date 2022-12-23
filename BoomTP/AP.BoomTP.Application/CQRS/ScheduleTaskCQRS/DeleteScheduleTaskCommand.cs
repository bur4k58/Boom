using AP.BoomTP.Application.CQRS.ScheduleCQRS;
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

namespace AP.BoomTP.Application.CQRS.ScheduleTaskCQRS
{
    public class DeleteScheduleTaskCommand : IRequest<ScheduleTaskIds>
    {
        public int? ScheduleId { get; set; }
        public int? TasksId { get; set; }
    }
    public class DeleteScheduleTaskValidator : AbstractValidator<DeleteScheduleTaskCommand>
    {
        public DeleteScheduleTaskValidator()
        {
            RuleFor(x => x.ScheduleId).NotEmpty().WithMessage("ScheduleId can not be null");
            RuleFor(x => x.TasksId).NotEmpty().WithMessage("TaskId can not be null");
        }
    }

    public class DeleteScheduleTaskCommandHandler : IRequestHandler<DeleteScheduleTaskCommand, ScheduleTaskIds>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public DeleteScheduleTaskCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<ScheduleTaskIds> Handle(DeleteScheduleTaskCommand request, CancellationToken cancellationToken)
        {
            ScheduleTask scheduleTask = await uow.ScheduleTaskRepository.GetByScheduleIdAndTaskId(request.ScheduleId.Value, request.TasksId.Value);
            uow.ScheduleTaskRepository.Delete(scheduleTask);
            await uow.Commit();
            return mapper.Map<ScheduleTaskIds>(scheduleTask);
        }
    }
}
