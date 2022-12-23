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
    public class UpdateUserCommand : IRequest<UserUpdate>
    {
        public int Id { get; set; }
        public string AuthId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public ContractType ContractType { get; set; }
    }

    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.AuthId).NotEmpty().WithMessage("AuthId can not be null");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName can not be null");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email can not be null");
        }
    }
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserUpdate>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public UpdateUserCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<UserUpdate> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User user = await uow.UserRepository.GetById(request.Id);
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.AuthId = request.AuthId;
            user.Email = request.Email;
            user.ContractType = (Domain.ContractType)request.ContractType;
            user.Role = (Domain.Role)request.Role;

            uow.UserRepository.Update(user);
            await uow.Commit();
            return mapper.Map<UserUpdate>(user);
        }
    }
}