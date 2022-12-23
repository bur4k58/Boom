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
    public class GetTaskByIdQuery : IRequest<TasksDTO>
    {
        public int Id { get; set; }
    }
    public class GetTasksByIdHandler : IRequestHandler<GetTaskByIdQuery, TasksDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper _mapper;
        public GetTasksByIdHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            _mapper = mapper;
        }
        public async Task<TasksDTO> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<TasksDTO>(await uow.TasksRepository.GetById(request.Id));
        }
    } 

}
