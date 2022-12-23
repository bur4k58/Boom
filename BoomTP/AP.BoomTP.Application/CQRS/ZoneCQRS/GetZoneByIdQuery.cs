using AP.BoomTP.Application.CQRS.GrowSiteCQRS;
using AP.BoomTP.Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.CQRS.ZoneCQRS
{
    public class GetZoneByIdQuery : IRequest<ZoneDTO>
    {
        public int Id { get; set; }

    }
    public class GetZoneByIdHandler : IRequestHandler<GetZoneByIdQuery, ZoneDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper _mapper;
        public GetZoneByIdHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            _mapper = mapper;
        }
        public async Task<ZoneDTO> Handle(GetZoneByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ZoneDTO>(await uow.ZoneRespository.GetById(request.Id));
        }
    }
}
