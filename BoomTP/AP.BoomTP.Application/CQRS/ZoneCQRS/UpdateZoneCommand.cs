using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
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
    public class UpdateZoneCommand : IRequest<ZoneDTO>
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string QrCode { get; set; }
        public int? GrowSiteId { get; set; }
        public int? TreeSpeciesId { get; set; }
    }
    public class UpdateZoneValidator : AbstractValidator<UpdateZoneCommand>
    {
        public UpdateZoneValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be null");
            RuleFor(x => x.GrowSiteId).NotEmpty().WithMessage("GrowSiteId can not be null");
            RuleFor(x => x.TreeSpeciesId).NotEmpty().WithMessage("TreeSpeciesId can not be null");
        }
    }
    public class UpdateZoneCommandHandler : IRequestHandler<UpdateZoneCommand, ZoneDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public UpdateZoneCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<ZoneDTO> Handle(UpdateZoneCommand request, CancellationToken cancellationToken)
        {
            Zone zone = await uow.ZoneRespository.GetById(request.Id);
            zone.Name = request.Name;
            zone.Size = request.Size;
            zone.TreeSpeciesId= request.TreeSpeciesId.Value;
            zone.GrowSiteId = request.GrowSiteId.Value;

            zone.QrCode = request.QrCode;
            uow.ZoneRespository.Update(zone);
            await uow.Commit();

            return mapper.Map<ZoneDTO>(zone);
        }
    }
}
