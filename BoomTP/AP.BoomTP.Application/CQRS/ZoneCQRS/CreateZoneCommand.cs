using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
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

namespace AP.BoomTP.Application.CQRS.ZoneCQRS
{
    public class CreateZoneCommand : IRequest<ZoneDTO>
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string QrCode { get; set; }
        public int? GrowSiteId { get; set; }
        public int? TreeSpeciesId { get; set; }
    }
    public class CreateZoneoCommandValidator : AbstractValidator<CreateZoneCommand>
    {
        public CreateZoneoCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be null");
            RuleFor(x => x.GrowSiteId).NotEmpty().WithMessage("GrowSiteId can not be null");
            RuleFor(x => x.TreeSpeciesId).NotEmpty().WithMessage("TreeSpeciesId can not be null");
        }
    }
    public class CreateZoneCommandHandler : IRequestHandler<CreateZoneCommand, ZoneDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public CreateZoneCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<ZoneDTO> Handle(CreateZoneCommand request, CancellationToken cancellationToken)
        {
            var zone = new Zone()
            {
                Name = request.Name,
                Size = request.Size,
                QrCode = request.QrCode,
                GrowSiteId = request.GrowSiteId.Value,
                TreeSpeciesId = request.TreeSpeciesId.Value
            };

            List<Zone> zones = await uow.ZoneRespository.GetAllZoneByGrowSiteAndTreeSpecies(zone.GrowSiteId, zone.TreeSpeciesId);

            if(zones.Count() >= 3)
            {
                throw new ZoneException("Boomsoort maximaal in 3 zones onderbrengen binnen 1 site");
            }

            uow.ZoneRespository.Create(zone);
            await uow.Commit();
            return mapper.Map<ZoneDTO>(zone);
        }
    }
}
