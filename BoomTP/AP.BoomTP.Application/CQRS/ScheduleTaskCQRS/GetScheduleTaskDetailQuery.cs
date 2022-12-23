using AP.BoomTP.Application.CQRS.ScheduleCQRS;
using AP.BoomTP.Application.CQRS.ScheduleStatusCQRS;
using AP.BoomTP.Application.CQRS.ScheduleTaskCQRS;
using AP.BoomTP.Application.CQRS.TasksCQRS;
using AP.BoomTP.Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.CQRS.ScheduleTaskCQRS
{
    public class GetScheduleTaskDetailQuery : IRequest<IEnumerable<ScheduleTaskDetailDTO>>
    {
        public int ScheduleId { get; set; }
    }
    public class GetScheduleTaskDetailHandler : IRequestHandler<GetScheduleTaskDetailQuery,IEnumerable<ScheduleTaskDetailDTO>>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper _mapper;
        public GetScheduleTaskDetailHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ScheduleTaskDetailDTO>> Handle(GetScheduleTaskDetailQuery request, CancellationToken cancellationToken)
        {
            var list = await uow.ScheduleTaskRepository.GetByScheduleId(request.ScheduleId);
            return (List<ScheduleTaskDetailDTO>)_mapper.Map<IEnumerable<ScheduleTaskDetailDTO>>(list);
        }
    }
}
