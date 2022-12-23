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
    public class GetGrowSiteByIdQuery : IRequest<GrowSiteDetailDTO>
    {
        public int Id { get; set; }
    }
    public class GetGrowSiteByIdHandler : IRequestHandler<GetGrowSiteByIdQuery, GrowSiteDetailDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper _mapper;

        public GetGrowSiteByIdHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            _mapper = mapper;
        }
        public async Task<GrowSiteDetailDTO> Handle(GetGrowSiteByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<GrowSiteDetailDTO>(await uow.GrowSiteRepository.GetById(request.Id));
        }
    }
}