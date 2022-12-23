using AP.BoomTP.Application.CQRS.ZoneCQRS;
using AP.BoomTP.Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.CQRS.ScheduleCQRS
{
    public class GetScheduleByIdQuery : IRequest<ScheduleDetailDTO>
    {
        public int Id { get; set; }
    }
    public class GetScheduleByIdHandler : IRequestHandler<GetScheduleByIdQuery, ScheduleDetailDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper _mapper;
        public GetScheduleByIdHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            _mapper = mapper;
        }
        public async Task<ScheduleDetailDTO> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ScheduleDetailDTO>(await uow.ScheduleRepository.GetById(request.Id));
        }
    }
}
