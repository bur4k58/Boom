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
    public class GetAllScheduleQuery : IRequest<IEnumerable<ScheduleDTO>>
    {
        public int pageNr { get; set; } = 1;
        public int pageSize { get; set; } = 10;
    }
    public class GetAllScheduleQueryHandler : IRequestHandler<GetAllScheduleQuery, IEnumerable<ScheduleDTO>>
    {
        private readonly IUnitofWork _uow;
        private readonly IMapper _mapper;

        public GetAllScheduleQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ScheduleDTO>> Handle(GetAllScheduleQuery request, CancellationToken cancellationToken)
        {
            var list = await _uow.ScheduleRepository.GetAll(request.pageNr, request.pageSize);
            var orderedDateList = list.OrderBy(x => x.Date);
            return _mapper.Map<IEnumerable<ScheduleDTO>>(orderedDateList);
        }
    }
}
