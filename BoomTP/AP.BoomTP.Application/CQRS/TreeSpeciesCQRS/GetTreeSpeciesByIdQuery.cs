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
    public class GetTreeSpeciesByIdQuery : IRequest<TreeSpeciesDetailDTO>
    {
        public int Id { get; set; }
    }
    public class GetTreeSpeciesByIdHandler : IRequestHandler<GetTreeSpeciesByIdQuery, TreeSpeciesDetailDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper _mapper;

        public GetTreeSpeciesByIdHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            _mapper = mapper;
        }
        public async Task<TreeSpeciesDetailDTO> Handle(GetTreeSpeciesByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<TreeSpeciesDetailDTO>(await uow.TreeSpeciesRepository.GetById(request.Id));
        }
    }
}
