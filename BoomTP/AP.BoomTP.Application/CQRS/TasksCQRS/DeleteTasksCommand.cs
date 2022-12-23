using AP.BoomTP.Application.CQRS.TreeSpeciesCQRS;
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

namespace AP.BoomTP.Application.CQRS.TasksCQRS
{
    public class DeleteTasksCommand : IRequest<TasksId>
    {
        public int Id { get; set; }

    }
    public class DeleteTasksValidator : AbstractValidator<DeleteTasksCommand>
    {
        public DeleteTasksValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id can not be null");
        }
    }
    public class DeleteTasksCommandHandler : IRequestHandler<DeleteTasksCommand, TasksId>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public DeleteTasksCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<TasksId> Handle(DeleteTasksCommand request, CancellationToken cancellationToken)
        {
            Tasks task = await uow.TasksRepository.GetById(request.Id);
            uow.TasksRepository.Delete(task);
            await uow.Commit();
            return mapper.Map<TasksId>(task);
        }
    }
}
