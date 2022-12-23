using AP.BoomTP.Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.CQRS.UserCQRS
{
    public class GetUserScheduleFilteredQuery : IRequest<IEnumerable<UserDTO>>
    {
        public string AuthId { get; set; }
    }
    public class GetUserScheduleFilteredHandler : IRequestHandler<GetUserScheduleFilteredQuery, IEnumerable<UserDTO>>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper _mapper;

        public GetUserScheduleFilteredHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> Handle(GetUserScheduleFilteredQuery request, CancellationToken cancellationToken)
        {
            var list = await uow.UserRepository.GetByAuthIdFilter(request.AuthId);
            return (List<UserDTO>)_mapper.Map<IEnumerable<UserDTO>>(list);
        }
    }
}
