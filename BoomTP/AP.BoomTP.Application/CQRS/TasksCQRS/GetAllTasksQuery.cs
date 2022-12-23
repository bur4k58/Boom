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

namespace AP.BoomTP.Application.CQRS.TasksCQRS
{
    public class GetAllTasksQuery : IRequest<IEnumerable<TasksDTO>>
    {
        public int pageNr { get; set; } = 1;
        public int pageSize { get; set; } = 10;
    }
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TasksDTO>>
    {
        private readonly IUnitofWork _uow;
        private readonly IMapper _mapper;

        public GetAllTasksQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TasksDTO>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var list = await _uow.TasksRepository.GetAll(request.pageNr, request.pageSize);
            return _mapper.Map<IEnumerable<TasksDTO>>(list);
        }
    }
}
