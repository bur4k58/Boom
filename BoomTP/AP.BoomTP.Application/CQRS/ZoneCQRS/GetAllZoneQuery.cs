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
    public class GetAllZoneQuery : IRequest<IEnumerable<ZoneDTO>>
    {
        public int pageNr { get; set; } = 1;
        public int pageSize { get; set; } = 10;

    }
    public class GetAllZoneQueryHandler : IRequestHandler<GetAllZoneQuery, IEnumerable<ZoneDTO>>
    {
        private readonly IUnitofWork _uow;
        private readonly IMapper _mapper;

        public GetAllZoneQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ZoneDTO>> Handle(GetAllZoneQuery request, CancellationToken cancellationToken)
        {
            var list = await _uow.ZoneRespository.GetAll(request.pageNr, request.pageSize);
            return _mapper.Map<IEnumerable<ZoneDTO>>(list);
        }
    }

}
