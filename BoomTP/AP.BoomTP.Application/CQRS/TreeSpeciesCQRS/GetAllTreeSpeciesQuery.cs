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

namespace AP.BoomTP.Application.CQRS.TreeSpeciesCQRS
{
    public class GetAllTreeSpeciesQuery : IRequest<IEnumerable<TreeSpeciesDTO>>
    {
        public int pageNr { get; set; } = 1;
        public int pageSize { get; set; } = 10;
    }
    public class GetAllTreeSpeciesQueryHandler : IRequestHandler<GetAllTreeSpeciesQuery, IEnumerable<TreeSpeciesDTO>>
    {
        private readonly IUnitofWork _uow;
        private readonly IMapper _mapper;

        public GetAllTreeSpeciesQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TreeSpeciesDTO>> Handle(GetAllTreeSpeciesQuery request, CancellationToken cancellationToken)
        {
            var list = await _uow.TreeSpeciesRepository.GetAll(request.pageNr, request.pageSize);
            return _mapper.Map<IEnumerable<TreeSpeciesDTO>>(list);
        }
    }
}
