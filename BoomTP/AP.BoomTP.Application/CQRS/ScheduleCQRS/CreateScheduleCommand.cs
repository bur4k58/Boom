using AP.BoomTP.Application.CQRS.UserCQRS;
using AP.BoomTP.Application.CQRS.ZoneCQRS;
using AP.BoomTP.Application.Exceptions;
using AP.BoomTP.Application.Interfaces;
using AP.BoomTP.Domain;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.CQRS.ScheduleCQRS
{
    public class CreateScheduleCommand : IRequest<ScheduleDetailDTO>
    {
        public DateTime Date { get; set; }
        public int? UserId { get; set; }
        public int? ZoneId { get; set; }
        public int[] TaskId { get; set;}
    }
    public class CreateScheduleCommandValidator : AbstractValidator<CreateScheduleCommand>
    {
        public CreateScheduleCommandValidator()
        {
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date can not be null");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId can not be null");
            RuleFor(x => x.ZoneId).NotEmpty().WithMessage("ZoneId can not be null");
        }
    }

    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, ScheduleDetailDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public CreateScheduleCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<ScheduleDetailDTO> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            List<Schedule> planning = (List<Schedule>)await uow.ScheduleRepository.GetAll(1, 20);
            List<Schedule> planningUser = await uow.ScheduleRepository.GetScheduleByDateAndUserId(request.Date, request.UserId.Value);
            float totalTasktime = 0;
            int totalTasks = 0;

            var schedule = new Schedule()
            {
                Date = request.Date,
                UserId = request.UserId.Value,
                ZoneId = request.ZoneId.Value,
                ScheduleTask = new List<ScheduleTask>()
            };

            foreach (Schedule plan in planning)
            {
                if (schedule.Date.Date == plan.Date.Date.AddDays(1) && schedule.ZoneId == plan.ZoneId && schedule.UserId == plan.UserId)
                {
                    throw new ScheduleException("Medewerkers mogen niet 2 dagen na elkaar in zelfde zone ingepland worden");
                }
                else if (schedule.Date.Date == plan.Date.Date && schedule.ZoneId == plan.ZoneId)
                {
                    throw new ScheduleException("Zone al ingepland");
                }
            }

            Calendar cal = new CultureInfo("en-US").Calendar;
            List<DayOfWeek> daysCheck = new List<DayOfWeek>();
            daysCheck.Add(schedule.Date.DayOfWeek);
            foreach (Schedule sitePlan in planning.Where(m => m.UserId == schedule.UserId))
            {
                if (cal.GetWeekOfYear(schedule.Date.Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday) == cal.GetWeekOfYear(sitePlan.Date.Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday))
                {
                    daysCheck.Add(sitePlan.Date.DayOfWeek);
                    if (daysCheck.Distinct().Count() > 5)
                    {
                        throw new ScheduleException("Medewerker mag niet meer dan 5 dagen in 1 week werken");
                    }
                }
            }

            User foundUser = await uow.UserRepository.GetById(schedule.UserId);
            Zone foundZone = await uow.ZoneRespository.GetById(schedule.ZoneId);
            List<Zone> zones = (List<Zone>)await uow.ZoneRespository.GetAll(1, 20);
            int countSites = 0;
            foreach (Schedule sitePlan in planning.Where(m => m.UserId == schedule.UserId))
            {
                foreach (Zone zone in zones.Where(n => n.GrowSiteId != foundZone.GrowSiteId && n.Id==sitePlan.ZoneId))
                {
                    if (cal.GetWeekOfYear(schedule.Date.Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday) == cal.GetWeekOfYear(sitePlan.Date.Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday))
                    {
                        countSites++;
                        if (foundUser.ContractType == 0)
                        {
                            if (countSites > 0)
                            {
                                throw new ScheduleException("Fulltime werker mag niet meer dan 1 site in 1 week hebben");
                            }
                        }
                        else
                        {
                            if (countSites > 1)
                            {
                                throw new ScheduleException("Deeltijds mag niet meer dan 2 sites in 1 week hebben");
                            }
                        }
                    }
                }
            }

            uow.ScheduleRepository.Create(schedule);
            
            foreach (Schedule plan in planningUser)
            {
                foreach (ScheduleTask scheduleTask in plan.ScheduleTask)
                {
                    Tasks task = await uow.TasksRepository.GetById(scheduleTask.TasksId);
                    totalTasktime += task.TaskTime;
                    totalTasks++;
                }
            }

            foreach (int i in request.TaskId)
            {
                Tasks task = await uow.TasksRepository.GetById(i);
                totalTasktime += task.TaskTime;
                if (totalTasktime < 480 && totalTasks <= 3)
                {
                    ScheduleTask scheduleTask = new ScheduleTask
                    {
                        Schedule = schedule,
                        Status = Status.Made,
                        Tasks = task
                    };
                    totalTasks++;
                    uow.ScheduleTaskRepository.Create(scheduleTask);
                }
                else if (totalTasktime > 480)
                {
                    throw new ScheduleException("Een medewerker mag niet meer dan 8uur werken.");
                }
                else if (totalTasks >= 4)
                {
                    throw new ScheduleException("Een medewerker mag maximaal 4 taken per dag toegekend krijgen.");
                }
            }

            await uow.Commit();
            return mapper.Map<ScheduleDetailDTO>(schedule);
        }
    }
}
