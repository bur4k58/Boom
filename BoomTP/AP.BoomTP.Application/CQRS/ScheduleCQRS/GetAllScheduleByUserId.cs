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
    public class GetAllScheduleByUserId : IRequest<IEnumerable<ScheduleDetailDTO>>
    {
        public int Id { get; set; }
    }

    public class GetAllScheduleByUserIdHandler : IRequestHandler<GetAllScheduleByUserId, IEnumerable<ScheduleDetailDTO>>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper _mapper;
        public GetAllScheduleByUserIdHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ScheduleDetailDTO>> Handle(GetAllScheduleByUserId request, CancellationToken cancellationToken)
        {

            var list = await uow.ScheduleRepository.GetAllScheduleByUserId(request.Id);
            return (List<ScheduleDetailDTO>)_mapper.Map<IEnumerable<ScheduleDetailDTO>>(list);
        }
    }
    }
