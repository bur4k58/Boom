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

namespace AP.BoomTP.Application.CQRS.ZoneCQRS
{
    public class DeleteZoneCommand : IRequest<ZoneId>
    {
        public int? Id { get; set; }
    }
    public class DeleteZoneValidator : AbstractValidator<DeleteZoneCommand>
    {
        public DeleteZoneValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id can not be null");
        }
    }
    public class DeleteZoneCommandHandler : IRequestHandler<DeleteZoneCommand, ZoneId>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public DeleteZoneCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<ZoneId> Handle(DeleteZoneCommand request, CancellationToken cancellationToken)
        {
            Zone zone = await uow.ZoneRespository.GetById(request.Id.Value);
            uow.ZoneRespository.Delete(zone);
            await uow.Commit();
            return mapper.Map<ZoneId>(zone);
        }
    }
}
