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
    public class UpdateGrowSiteCommand : IRequest<GrowSiteDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Map { get; set; }
    }
    public class UpdateGrowSiteValidator : AbstractValidator<UpdateGrowSiteCommand>
    {
        public UpdateGrowSiteValidator()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Addresses can not be null");
        }
    }
    public class UpdateGrowSiteCommandHandler : IRequestHandler<UpdateGrowSiteCommand, GrowSiteDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public UpdateGrowSiteCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<GrowSiteDTO> Handle(UpdateGrowSiteCommand request, CancellationToken cancellationToken)
        {
            GrowSite growSite = await uow.GrowSiteRepository.GetById(request.Id);
            growSite.Name = request.Name;
            growSite.Address = request.Address;
            growSite.Map = request.Map;

            uow.GrowSiteRepository.Update(growSite);
            await uow.Commit();

            return mapper.Map<GrowSiteDTO>(growSite);
        }
    }
}