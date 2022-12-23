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
    public class DeleteUserCommand : IRequest<UserId>
    {
        public int? Id { get; set; }
    }
    public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id can not be null");
        }
    }
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, UserId>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public DeleteUserCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<UserId> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User user = await uow.UserRepository.GetById(request.Id.Value);
            uow.UserRepository.Delete(user);
            await uow.Commit();
            return mapper.Map<UserId>(user);
        }
    }
}