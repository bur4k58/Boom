using AP.BoomTP.Application.CQRS.TreeSpeciesCQRS;
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
    public class DeleteScheduleCommand : IRequest<ScheduleId>
    {
        public int? Id { get; set; }
    }

    public class DeleteScheduleValidator : AbstractValidator<DeleteScheduleCommand>
    {
        public DeleteScheduleValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id can not be null");
        }
    }

    public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand, ScheduleId>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public DeleteScheduleCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<ScheduleId> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            Schedule schedule = await uow.ScheduleRepository.GetById(request.Id.Value);
            uow.ScheduleRepository.Delete(schedule);
            await uow.Commit();
            return mapper.Map<ScheduleId>(schedule);
        }
    }
}
