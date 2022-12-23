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

namespace AP.BoomTP.Application.CQRS.GrowSiteCQRS
{
    public class CreateGrowSiteCommand : IRequest<GrowSiteDTO>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Map { get; set; }

    }

    public class CreateGrowSiteValidator : AbstractValidator<CreateGrowSiteCommand>
    {
        public CreateGrowSiteValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name can not be null");
            RuleFor(x => x.Address).NotNull().WithMessage("Addresses can not be null");
        }
    }
    public class CreateGrowSiteCommandHandler : IRequestHandler<CreateGrowSiteCommand, GrowSiteDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public CreateGrowSiteCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<GrowSiteDTO> Handle(CreateGrowSiteCommand request, CancellationToken cancellationToken)
        {
            var growSite = new GrowSite()
            {
                Name = request.Name,
                Address = request.Address,
                Map = request.Map
            };
            uow.GrowSiteRepository.Create(growSite);
            await uow.Commit();
            return mapper.Map<GrowSiteDTO>(growSite);
        }
    }
}