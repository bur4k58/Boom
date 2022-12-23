using AP.BoomTP.Application.CQRS.ScheduleCQRS;
using AP.BoomTP.Application.CQRS.ZoneCQRS;
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
    public class CreateTasksCommand : IRequest<TasksDTO>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float TaskTime { get; set; }
        public int[] TreeSpeciesIds { get; set; }

    }
    public class CreateTasksValidator : AbstractValidator<CreateTasksCommand>
    {
        public CreateTasksValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title can not be null");
        }
    }
    public class CreateTasksCommandHandler : IRequestHandler<CreateTasksCommand, TasksDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public CreateTasksCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<TasksDTO> Handle(CreateTasksCommand request, CancellationToken cancellationToken)
        {
            var task = new Tasks()
            {
                Title = request.Title,
                Description = request.Description,
                TaskTime = request.TaskTime
            };

            uow.TasksRepository.Create(task);
            await uow.Commit();
            return mapper.Map<TasksDTO>(task);
        }
    }
}