using AP.BoomTP.Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.CQRS.GrowSiteCQRS
{
    public class GetAllGrowSiteQuery : IRequest<IEnumerable<GrowSiteDTO>>
    {
        public int pageNr { get; set; } = 1;
        public int pageSize { get; set; } = 10;
    }
    public class GetAllGrowSiteQueryHandler : IRequestHandler<GetAllGrowSiteQuery, IEnumerable<GrowSiteDTO>>
    {
        private readonly IUnitofWork _uow;
        private readonly IMapper _mapper;

        public GetAllGrowSiteQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GrowSiteDTO>> Handle(GetAllGrowSiteQuery request, CancellationToken cancellationToken)
        {
            var list = await _uow.GrowSiteRepository.GetAll(request.pageNr, request.pageSize);
            return _mapper.Map<IEnumerable<GrowSiteDTO>>(list);
        }
    }
}