using AP.BoomTP.Application.CQRS.TreeSpeciesCQRS;
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

namespace AP.BoomTP.Application.CQRS.ScheduleCQRS
{
    public class UpdateScheduleCommand : IRequest<ScheduleDetailDTO>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? ZoneId { get; set; }
        public int UserId { get; set; }
        public int[] TaskId { get; set; }
    }

    public class UpdateScheduleValidator : AbstractValidator<UpdateScheduleCommand>
    {
        public UpdateScheduleValidator()
        {
            RuleFor(x => x.ZoneId).NotEmpty().WithMessage("ZoneId can not be null");
        }
    }
    public class UpdateScheduleCommandHandler : IRequestHandler<UpdateScheduleCommand, ScheduleDetailDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public UpdateScheduleCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<ScheduleDetailDTO> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
        {
            Schedule schedule = await uow.ScheduleRepository.GetById(request.Id);
            schedule.Date = request.Date;
            schedule.UserId = request.UserId;
            schedule.ZoneId = request.ZoneId.Value;

            foreach (int i in request.TaskId)
            {
                ScheduleTask scheduleTask = await uow.ScheduleTaskRepository.GetByScheduleIdAndTaskId(schedule.Id, i);
                if (scheduleTask == null)
                {
                    Tasks task = await uow.TasksRepository.GetById(i);
                    ScheduleTask scheduleTaskNew = new ScheduleTask
                    {
                        Schedule = schedule,
                        Status = Status.Made,
                        Tasks = task
                    };
                    uow.ScheduleTaskRepository.Create(scheduleTaskNew);
                }
            }

            uow.ScheduleRepository.Update(schedule);
            await uow.Commit();

            return mapper.Map<ScheduleDetailDTO>(schedule);
        }
    }
}
