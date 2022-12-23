using AP.BoomTP.Application.Interfaces;
using AP.BoomTP.Domain;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AP.BoomTP.Application.CQRS.UserCQRS
{
    public class CreateUserCommand : IRequest<UserDTO>
    {
        public string AuthId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public ContractType ContractType { get; set; }

    }
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.AuthId).NotEmpty().WithMessage("AuthId can not be null");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName can not be null");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email can not be null");
        }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public CreateUserCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                AuthId = request.AuthId,
                Email = request.Email,
                ContractType = (Domain.ContractType)request.ContractType,
                Role = (Domain.Role)request.Role
            };
            uow.UserRepository.Create(user);
            await uow.Commit();
            return mapper.Map<UserDTO>(user);
        }
    }
}