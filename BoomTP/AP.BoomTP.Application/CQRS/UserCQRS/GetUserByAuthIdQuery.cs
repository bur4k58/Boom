using AP.BoomTP.Application.CQRS.ScheduleCQRS;
using AP.BoomTP.Application.Interfaces;
using AP.BoomTP.Domain;
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
    public class GetUserByAuthIdQuery : IRequest<IEnumerable<UserDTO>>
    {
       
            public string AuthId { get; set; }
    }
        public class GetUserByAuthIdHandler : IRequestHandler<GetUserByAuthIdQuery, IEnumerable<UserDTO>>
        {
            private readonly IUnitofWork uow;
            private readonly IMapper _mapper;

            public GetUserByAuthIdHandler(IUnitofWork uow, IMapper mapper)
            {
                this.uow = uow;
                _mapper = mapper;
            }

        public async Task<IEnumerable<UserDTO>> Handle(GetUserByAuthIdQuery request, CancellationToken cancellationToken)
            {
            var list = await uow.UserRepository.GetByAuthId(request.AuthId);

            return (List<UserDTO>)_mapper.Map<IEnumerable<UserDTO>>(list);
        }
        }
}
